using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

class TextEditor : ITextEditor
{
    private Trie<BigList<char>> userStrings;
    private Trie<Stack<string>> userStacks;

    public TextEditor()
    {
        userStrings = new Trie<BigList<char>>();
        userStacks = new Trie<Stack<string>>();
    }

    public void Login(string username)
    {
        userStrings.Insert(username, new BigList<char>());
        userStacks.Insert(username, new Stack<string>());
    }

    public void Logout(string username)
    {
        userStrings.Delete(username);
        userStacks.Delete(username);
    }

    public void Prepend(string username, string str)
    {
        if (!userStrings.Contains(username))
        {
            return;
        }

        SaveCurrentString(username);

        userStrings.GetValue(username).AddRangeToFront(str);
    }

    public void Insert(string username, int index, string str)
    {
        if (!userStrings.Contains(username))
        {
            return;
        }

        if (index < 0 || index >= Length(username))
        {
            return;
        }

        SaveCurrentString(username);

        userStrings.GetValue(username).InsertRange(index, str);
    }

    public void Substring(string username, int startIndex, int length)
    {
        if (!userStrings.Contains(username))
        {
            return;
        }

        if (startIndex < 0 || startIndex + length >= Length(username))
        {
            return;
        }

        SaveCurrentString(username);

        userStrings.Insert(username, 
            new BigList<char>(userStrings
                .GetValue(username)
                .Range(startIndex, length)));
    }

    public void Delete(string username, int startIndex, int length)
    {
        if (!this.userStrings.Contains(username))
        {
            return;
        }

        if (startIndex < 0 || startIndex + length >= Length(username))
        {
            return;
        }

        SaveCurrentString(username);

        userStrings.GetValue(username).RemoveRange(startIndex, length);
    }

    public void Clear(string username)
    {
        if (!userStrings.Contains(username))
        {
            return;
        }

        SaveCurrentString(username);

        userStrings.Insert(username, new BigList<char>());
    }

    public int Length(string username)
    {
        return GetUserString(username).Length;
    }

    public string Print(string username)
    {
        return GetUserString(username);
    }

    public void Undo(string username)
    {
        if (!userStrings.Contains(username))
        {
            return;
        }

        if (userStacks.GetValue(username).Count == 0)
        {
            return;
        }

        var lastUserString = userStacks.GetValue(username).Pop();

        SaveCurrentString(username);

        userStrings.Insert(username, new BigList<char>(lastUserString));
    }

    public IEnumerable<string> Users(string prefix = "")
    {
        return userStrings.GetByPrefix(prefix);
    }

    private string GetUserString(string username)
    {
        if (!userStrings.Contains(username))
        {
            return String.Empty;
        }

        return string.Join("", userStrings.GetValue(username));
    }

    private void SaveCurrentString(string username)
    {
        if (!userStrings.Contains(username))
        {
            return;
        }

        if (Length(username) == 0)
        {
            return;
        }

        userStacks.GetValue(username).Push(GetUserString(username));
    }
}
