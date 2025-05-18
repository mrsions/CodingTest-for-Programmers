from collections import deque

def solution(maze):
    """
    maze: 2차원 리스트
      0: 빈칸
      1: 빨간 수레의 시작 칸
      2: 파란 수레의 시작 칸
      3: 빨간 수레의 도착 칸
      4: 파란 수레의 도착 칸
      5: 벽
    
    리턴값: 퍼즐을 푸는데 필요한 최소 턴 수. 불가능하면 0.
    """
    n = len(maze)
    m = len(maze[0])

    # 위치 (r, c)를 bitmask 인덱스로 변환
    def pos_to_idx(r, c):
        return r * m + c

    # bitmask에서 idx 위치를 방문했는지 확인
    def visited_check(bitmask, idx):
        return (bitmask & (1 << idx)) != 0

    # bitmask에 idx 위치 방문 처리
    def visited_set(bitmask, idx):
        return bitmask | (1 << idx)

    # 범위 체크
    def in_range(r, c):
        return 0 <= r < n and 0 <= c < m

    # 빨간/파란 시작, 목표 위치 찾기
    r_start = b_start = (-1, -1)
    r_goal  = b_goal  = (-1, -1)
    for i in range(n):
        for j in range(m):
            if maze[i][j] == 1:   # 빨간 수레 시작
                r_start = (i, j)
            elif maze[i][j] == 2: # 파란 수레 시작
                b_start = (i, j)
            elif maze[i][j] == 3: # 빨간 수레 도착
                r_goal = (i, j)
            elif maze[i][j] == 4: # 파란 수레 도착
                b_goal = (i, j)

    # 목표 위치를 bit index로
    r_goal_idx = pos_to_idx(*r_goal)
    b_goal_idx = pos_to_idx(*b_goal)

    # 시작 상태: (r_pos, b_pos, r_visited, b_visited, turn)
    r_sidx = pos_to_idx(*r_start)
    b_sidx = pos_to_idx(*b_start)
    r_visited = visited_set(0, r_sidx)
    b_visited = visited_set(0, b_sidx)

    queue = deque()
    queue.append((r_sidx, b_sidx, r_visited, b_visited, 0))

    visited_states = set()
    visited_states.add((r_sidx, b_sidx, r_visited, b_visited))

    directions = [(-1, 0), (1, 0), (0, -1), (0, 1)]

    # BFS
    while queue:
        r_pos, b_pos, r_bit, b_bit, turn = queue.popleft()

        # 둘 다 자기 목표 위치에 도착했으면 성공
        if r_pos == r_goal_idx and b_pos == b_goal_idx:
            return turn

        # 현재 (r, c), (b, c) 좌표 복구
        rr, rc = divmod(r_pos, m)
        br, bc = divmod(b_pos, m)

        # 4방향 이동 시도
        for dr, dc in directions:
            # ---------------------------
            # 1) 빨간 수레 이동 처리
            # ---------------------------
            if r_pos == r_goal_idx:
                # 이미 도착 칸이면 움직이지 않음
                nr_pos = r_pos
                nr_bit = r_bit
            else:
                nr = rr + dr
                nc = rc + dc
                # 범위 벗어나거나 벽이면 불가
                if not in_range(nr, nc) or maze[nr][nc] == 5:
                    continue
                nr_pos = pos_to_idx(nr, nc)
                # 이미 방문한 칸이면 불가
                if visited_check(r_bit, nr_pos):
                    continue
                nr_bit = visited_set(r_bit, nr_pos)

            # ---------------------------
            # 2) 파란 수레 이동 처리
            # ---------------------------
            if b_pos == b_goal_idx:
                # 이미 도착 칸이면 움직이지 않음
                nb_pos = b_pos
                nb_bit = b_bit
            else:
                nr_b = br + dr
                nc_b = bc + dc
                # 범위 벗어나거나 벽이면 불가
                if not in_range(nr_b, nc_b) or maze[nr_b][nc_b] == 5:
                    continue
                nb_pos = pos_to_idx(nr_b, nc_b)
                # 이미 방문한 칸이면 불가
                if visited_check(b_bit, nb_pos):
                    continue
                nb_bit = visited_set(b_bit, nb_pos)

            # ---------------------------
            # 3) 두 수레가 같은 칸으로 이동?
            # ---------------------------
            if nr_pos == nb_pos:
                # 둘 다 도착지가 아닌 칸으로 겹쳤다면 불가능
                # (만약 한쪽이 자기 목표라서 '안 움직인' 게 아니면 충돌)
                if nr_pos != r_goal_idx and nb_pos != b_goal_idx:
                    continue

            # ---------------------------
            # 4) 두 수레가 서로 자리를 바꾸는지 체크
            # ---------------------------
            #  예: (r_pos, b_pos) -> (nr_pos, nb_pos)가 (b_pos, r_pos)이면 swap
            if nr_pos == b_pos and nb_pos == r_pos:
                # 둘 다 도착지가 아닌 상태에서 swap이면 불가능
                if r_pos != r_goal_idx and b_pos != b_goal_idx:
                    continue

            new_state = (nr_pos, nb_pos, nr_bit, nb_bit)
            if new_state not in visited_states:
                visited_states.add(new_state)
                queue.append((nr_pos, nb_pos, nr_bit, nb_bit, turn + 1))

    # 큐가 빌 때까지 성공 못 했으면 불가능
    return 0


if __name__ == "__main__":
    # 예시 테스트
    maze1 = [
        [1, 4],
        [0, 0],
        [2, 3]
    ]
    print("maze1 결과:", solution(maze1))  # 정상이라면 3

    maze2 = [
        [1, 0, 2],
        [0, 0, 0],
        [5, 0, 5],
        [4, 0, 3]
    ]
    print("maze2 결과:", solution(maze2))  # 정상이라면 7

    maze3 = [
        [1, 5],
        [2, 5],
        [4, 5],
        [3, 5]
    ]
    print("maze3 결과:", solution(maze3))  # 정상이라면 0

    maze4 = [
        [4, 1, 2, 3]
    ]
    print("maze4 결과:", solution(maze4))  # 정상이라면 0
