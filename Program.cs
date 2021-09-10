using System;
using System.IO;

namespace shaderception_standalone
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("No program file passed!");
                return;
            }

            // Make compiler
            Compiler compiler = new Compiler();
            compiler.input = new UnityEngine.UI.InputField();
            compiler.output = new UnityEngine.UI.Text();
            compiler.screenMat = new UnityEngine.Material();

            // Compile program
            compiler.input.text = File.ReadAllText(args[0]);
            compiler.Compile();

            // Dump output
            //Console.WriteLine(compiler.output.text);
            File.WriteAllText(args[0] + ".asm", compiler.output.text);
            File.WriteAllBytes(args[0] + ".bin", compiler.screenMat.binary);
        }
    }
}
