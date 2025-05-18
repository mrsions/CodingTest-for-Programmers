Test2.Add<Solution>((solution) => solution.solution(new int[,] { { 1, 0, 2 }, { 0, 0, 0 }, { 5, 0, 5 }, { 4, 0, 3 } }) == 7);
Test2.Run();