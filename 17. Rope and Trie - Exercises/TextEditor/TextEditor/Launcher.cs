using System;

class Program
{
    static void Main(string[] args)
    {
        TextEditor stringEditor = new TextEditor();

        var input = Console.ReadLine();

        while (!input.Equals("end"))
        {
            var tokens = input.Split();

            if (tokens[0].Equals("login"))
            {
                stringEditor.Login(tokens[1]);
            }
            else if (tokens[0].Equals("logout"))
            {
                stringEditor.Logout(tokens[1]);
            }
            else if (tokens[0].Equals("users"))
            {
                var filter = (tokens.Length > 1) ? 
                    tokens[1] : String.Empty;
                var users = stringEditor.Users(filter);

                Console.WriteLine(string.Join("\n", users));
            }
            else
            {
                var user = tokens[0];
                var command = tokens[1];

                switch (command)
                {
                    case "insert":
                    {
                        var text = input.Split('"')[1];
                        stringEditor.Insert(user, int.Parse(tokens[2]), text);
                        break;
                    }
                    case "prepend":
                    {
                        var text = input.Split('"')[1];
                        stringEditor.Prepend(user, text);
                        break;
                    }
                    case "substring":
                    {
                        stringEditor.Substring(user, int.Parse(tokens[2]), int.Parse(tokens[3]));
                        break;
                    }
                    case "delete":
                    {
                        stringEditor.Delete(user, int.Parse(tokens[2]), int.Parse(tokens[3]));
                        break;
                    }
                    case "clear":
                    {
                        stringEditor.Clear(user);
                        break;
                    }
                    case "length":
                    {
                        Console.WriteLine(stringEditor.Length(user));
                        break;
                    }
                    case "print":
                    {
                        Console.WriteLine(stringEditor.Print(user));
                        break;
                    }
                    case "undo":
                    {
                        stringEditor.Undo(user);
                        break;
                    }
                    default:
                        break;
                }
            }

            input = Console.ReadLine();
        }
    }
}

