using Exercise03;
using TextFileProcessorDI;

var service = new Take20Processor();
var processor = new TextFileProcessor(service);
var path = @"C:\Users\infosys\source\repos\OOP2026\Chapter15\演習問題\Exercise03\吾輩は猫である.txt";
processor.Run(path);