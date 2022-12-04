const char X = 'X';
const char O = 'O'; 
var currentPlayer = X;
char winner = ' ';
var board = new char[3, 3] { { '-', '-', '-' },
                             { '-', '-', '-' },
                             { '-', '-', '-' } };

PrintBoard(board);

//consider introducing a variable to track if the game is over 
while (!GameOver(board, ref winner))
{
    
    Console.WriteLine($"Player {currentPlayer}, your move!");
    Console.Write($"Please enter your move in row,col format (0,1 for example): ");

    var moveCoordinates = GetPlayerMove(board);
    //set move for the current player
    board[moveCoordinates[0], moveCoordinates[1]] = currentPlayer;
    
    PrintBoard(board);
    currentPlayer = currentPlayer == X ? O : X;
}

if (winner != ' ')
{
    Console.WriteLine($"Player {winner} wins!!");
}
else
{
    Console.WriteLine("Meow!");
}

static bool GameOver(char[,] board, ref char winner)
{
    winner = CheckForWinner(board);
    if (winner != ' ' || (winner == ' ' && !AreMovesAvailable(board)))
    {
        return true; 
    }
    return false;
}

static bool AreMovesAvailable(char[,] board)
{
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 3; col++)
        {
            if (board[row, col] == '-')
            {
                return true;
            }
        }
    }
    return false;
}

static void PrintBoard(char[,] board)
{
    Console.Clear();
    Console.WriteLine(" 012");
    for (int row = 0; row < 3; row++)
    {
        Console.Write(row);
        for (int col = 0; col < 3; col++)
        {
            Console.Write(board[row, col]);
        }
        Console.Write(Environment.NewLine);
    }
}

static int[] GetPlayerMove(char[,] board)
{
    bool moveIsValid = false;
    var moveCoordinates = new int[2];
    while (!moveIsValid)
    {
        var input = Console.ReadLine();
        try
        {
            moveCoordinates = ParseInputs(input);
            if (moveCoordinates[0] > 2 || moveCoordinates[1] > 2 || board[moveCoordinates[0], moveCoordinates[1]] != '-')
            {
                throw new Exception();
            }
            moveIsValid = true;
        }
        catch
        {
            Console.WriteLine("Whoopsie daisy, not a valid move, try again!");
        }
    }
    return moveCoordinates;
}

static int[] ParseInputs(string input)
{
    int[] convertedCoordinates = new int[2]; 
    var coordinates = input.Split(',');
    convertedCoordinates[0] = int.Parse(coordinates[0]);
    convertedCoordinates[1] = int.Parse(coordinates[1]);
    return convertedCoordinates;
}

static char CheckForWinner(char[,] board)
{
    //investigate returning a bool? 
    //return CheckRowsForWin(board) || CheckColsForWin(board) || CheckDiagonalsForWin(board);
    char winner;
    winner = CheckRowsForWin(board);
    if (winner != ' ')
    {
        return winner;
    }
    winner = CheckColsForWin(board);
    if (winner != ' ')
    {
        return winner;
    }
    winner = CheckDiagonalsForWin(board);
    if (winner != ' ')
    {
        return winner;
    }

    return winner;
}

static char CheckRowsForWin(char[,] board)
{
    for (int row = 0; row < 3; row++)
    {
        for (int col = 0; col < 2; col++)
        {
            if (board[row, col] == '-' || board[row, col] != board[row, col + 1])
                break;
            else if (col == 1)
            {
                return board[row, col];
            }
        }
    }
    return ' ';
}

static char CheckColsForWin(char[,] board)
{
    for (int col = 0; col < 3; col++)
    {
        for (int row = 0; row < 2; row++)
        {
            if (board[row, col] == '-' || board[row, col] != board[row + 1, col])
                break;
            else if (row == 1)
            {
                return board[row, col];
            }
        }
    }
    return ' ';
}

static char CheckDiagonalsForWin(char[,] board)
{
    for (int row = 0, col = 0; row < 3; row++, col++)
    {
        if (board[row, col] == '-' || board[row, col] != board[row + 1, col + 1])
            break;
        else if (row == 1)
        {
            return board[row, col];
        }
    }

    for (int row = 0, col = 2; row < 3; row++, col--)
    {
        if (board[row, col] == '-' || board[row, col] != board[row + 1, col - 1])
            break;
        else if (row == 1)
        {
            return board[row, col];
        }
    }
    return ' ';
}