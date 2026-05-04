namespace PlayersGuide.Level6;

public static class TheVariableShop
{
    public static void Solution()
    {
        byte b = 255;
        short s = 100;
        int i = 1000;
        long l = 10000;
        sbyte sb = -100;
        ushort us = 200;
        uint ui = 2000;
        ulong ul = 20000;
        char c = 'A';
        string str = "Hello, World!";
        float f = 3.14f;
        double d = 3.14159;
        decimal dec = 3.141592653589793238462643383279m;
        bool boolTrue = true;

        Console.WriteLine(b);
        Console.WriteLine(s);
        Console.WriteLine(i);
        Console.WriteLine(l);
        Console.WriteLine(sb);
        Console.WriteLine(us);
        Console.WriteLine(ui);
        Console.WriteLine(ul);
        Console.WriteLine(c);
        Console.WriteLine(str);
        Console.WriteLine(f);
        Console.WriteLine(d);
        Console.WriteLine(dec);
        Console.WriteLine(boolTrue);

        b = 210;
        s = 150;
        i = 1234;
        l = 56789;
        sb = -120;
        us = 230;
        ui = 2500;
        ul = 30000;
        c = 'B';
        str = "Hello, C#!";
        f = 6.28f;
        d = 6.28318;
        dec = 6.283185307179586476925286766559m;
        boolTrue = false;

        Console.WriteLine(b);
        Console.WriteLine(s);
        Console.WriteLine(i);
        Console.WriteLine(l);
        Console.WriteLine(sb);
        Console.WriteLine(us);
        Console.WriteLine(ui);
        Console.WriteLine(ul);
        Console.WriteLine(c);
        Console.WriteLine(str);
        Console.WriteLine(f);
        Console.WriteLine(d);
        Console.WriteLine(dec);
        Console.WriteLine(boolTrue);
    }
}
