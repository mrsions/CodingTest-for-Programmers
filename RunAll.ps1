$csprojFiles = Get-ChildItem -Recurse -Filter *.csproj | Where-Object { $_.BaseName -notlike '_*' }
$totalProjects = $csprojFiles.Count
$jobs = @()

Write-Host "$($csprojFiles.Count)개 프로젝트 감지됨"

foreach ($csproj in $csprojFiles) {
    $csprojBaseName = $csproj.BaseName
    $projectPath = $csproj.FullName
    $projectDir = Split-Path -Parent $projectPath
	
    # 비동기 작업 생성 (Job)
    $job = Start-Job -ScriptBlock {
        param ($projectPath, $projectDir, $csprojBaseName)

        # 빌드 (Debug 모드로)
        dotnet build $projectPath -c Debug > $null
        if ($LASTEXITCODE -ne 0) {
            return "'$csprojBaseName' 실패 (빌드 오류)"
        }

        # 재귀적으로 exe 파일 검색
        $exeFile = Get-ChildItem -Path $projectDir -Recurse -Filter *.exe | Select-Object -First 1

        if ($exeFile) {
            # exe 파일 실행
            $process = Start-Process -FilePath $exeFile.FullName -ArgumentList '-nowait' -PassThru -WindowStyle Hidden
			$process.WaitForExit()
			
            if ($process.ExitCode -eq 0) {
                return "'$csprojBaseName' 성공"
            } else {
                return "'$csprojBaseName' 실패"
            }
        } else {
            return "'$csprojBaseName' 실패 (exe 파일 없음)"
        }
    } -ArgumentList $projectPath, $projectDir, $csprojBaseName
	
    # 작업 목록에 추가
    $jobs += $job
}

$number = 0
# 작업이 끝날 때까지 주기적으로 결과 확인
while ($jobs.Count -gt 0) {
    foreach ($job in $jobs) {
        if ($job.State -eq 'Completed') {
            # 작업 결과 출력
            $result = Receive-Job -Job $job
			$number++
			$msg = "[$number/$totalProjects] $result";
			
			if($result -like '*실패*')
			{
				Write-Host $msg -ForegroundColor Red
			}
			else
			{
				Write-Host $msg
			}
			
            # 완료된 작업 제거
            Remove-Job -Job $job
            $jobs = $jobs | Where-Object { $_.Id -ne $job.Id }
        }
    }

    # 잠시 대기 (CPU 점유율 방지)
    Start-Sleep -Milliseconds 500
}

Write-Host ""
pause