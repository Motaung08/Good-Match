using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matcher {
    class MainClass {        
        public static bool ValidString(string line){
            for(int i=0;i<line.Length;++i){
                char c = line[i];

                if(Char.IsLetter(c) || Char.IsWhiteSpace(c)){
                    continue;
                }

                else{
                    return false;
                }
            }
            return true;
        }

        public static Dictionary<char, int> CountChars(string line){
            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach (char c in line){
                if(counts.ContainsKey(c) && !Char.IsWhiteSpace(c)){
                    counts[c] = counts[c]+1;
                }
                else if(!Char.IsWhiteSpace(c)){
                    counts[c] = 1;
                }
            }
            return counts;
        }

        public static string MakeNumber(string line){
            Dictionary<char, int> counts = CountChars(line);
            Dictionary<char,int> processedChars = new Dictionary<char,int>();   
            string number = "";

            foreach(char c in line){
                if(!processedChars.ContainsKey(c) && counts.ContainsKey(c)){
                    number = number+counts[c];
                    processedChars[c] = -1;
                }
            }
            return number;
        }

        public static string ReduceNumber(string number){
            string newNumber = "";
            int left = 0;
            int right = number.Length-1;
            int n = number.Length;

            // escape hatch
            if(n==2){
                return number;
            }

            while (true){
                // if string length is odd this works
                if(left==right && n%2!=0){
                    int s = int.Parse(number[left].ToString());
                    newNumber = newNumber+s.ToString();
                    break;
                }
                // otherwise string length even this works
                else if(left+1==right && n%2==0){
                    int s = int.Parse(number[left].ToString()) + int.Parse(number[right].ToString());
                    newNumber = newNumber+s.ToString();
                    break;
                }
                
                // otherwise continue as specified
                int sum = int.Parse(number[left].ToString()) + int.Parse(number[right].ToString());  
                newNumber = newNumber+sum.ToString();
                left = left+1;
                right = right-1;
            }

            return ReduceNumber(newNumber);
        }

        public static int CalculateMatch(string line){
            string number = MakeNumber(line);
            string reducedNumber = ReduceNumber(number);
            int match = int.Parse(reducedNumber);
            return match;
        }

        // reading,validation and formating of input then parse to calculate match

        public static void Main (string[] args) {
            string line = Console.ReadLine();
            // string filePath = @"C:\devrico\input.csv";
            // string [] line = File.ReadAllLines(filePath);

            // List<string> lines = new List<string>();
            // lines = File.ReadAllLines(filePath).ToList();

            // foreach (String line in lines)
            // {
            //     Console.WriteLine(line);
            // }
            // Console.ReadLine();
            int match = CalculateMatch(line);
            Console.WriteLine(match);           
        }
    }
}