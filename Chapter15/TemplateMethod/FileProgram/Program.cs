using System.Diagnostics.Tracing;
using TextFileProcessor;

string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\Section04\Program.cs";
TextProcessor.Run<FileProgramProcessor>(path);

public class FileProgramProcessor : TextProcessor {

    private int _count = 0;
    string? _words;
    
    protected override void Initialize(string fname) {
        Console.Write("カウントしたい単語:");
        _words = Console.ReadLine();
        _count = 0;
    }

    protected override void Execute(string line) {
        
        //if (line.Contains(_words)) {
        //    _count++;
        //}

        if (string.IsNullOrEmpty(_words))
            return;
 
        int index = 0;

        while ((index = line.IndexOf(_words, index)) >= 0) {
            _count++;
            index += _words.Length;
        }

    }
        
    protected override void Terminate() =>

        Console.WriteLine("「{0}」は{1}個出現します!", _words, _count);
}