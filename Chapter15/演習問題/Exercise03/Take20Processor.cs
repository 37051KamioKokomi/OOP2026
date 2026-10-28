using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessorDI;

namespace Exercise03 {
    internal class Take20Processor : ITextFileService{
        private int _count = 0;
        private string _line = ""; 

        public void Initialize(string fname) => _count = 0;

        public void Execute(string lines) {
            _count++;
            
            if(_count <= 20) {
                Console.WriteLine(lines);
            }
        }

        public void Terminate() {

        }
    }
}
