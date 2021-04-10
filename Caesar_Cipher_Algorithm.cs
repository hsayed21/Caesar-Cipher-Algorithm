/*
Name: Caesar Cipher Algorithm
Description: This file contains the implementation of algorithm
Source url: https://github.com/hsayed21/Caesar-Cipher-Algorithm
Author: Hamada Sayed(x00h)[https://github.com/hsayed21]
License: Apache License 2.0
License:
   Copyright 2020 x00h

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;

namespace Caesar_Cipher_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        { 
            string str;
            int key;
            Dictionary<char, int> MyChars = new Dictionary<char, int>();
            Init(MyChars);
            
            Console.Write("[1] Encrypt or [2] Decrypt ? ");
            int choose = int.Parse(Console.ReadLine());

            if (choose == 1)
            {
                GetDataFromUser("Encrypt", out str, out key);
                Encrypt(str, key, MyChars);
            }
            else if (choose == 2)
            {
                GetDataFromUser("Decrypt", out str, out key);
                Decrypt(str, key, MyChars);
            }
            else
            {
                Console.WriteLine("Invaild value, try again!! :)");
            }

            Console.ReadKey();
        }
        
        public static void Init(Dictionary<char,int> MyChars)
        {
            char c = 'a';
            int cIndex = 0;

            for (; c <= 'z'; c++, cIndex++)
            {
                MyChars.Add(c, cIndex); 
            }
        }

        public static void GetDataFromUser(string t, out string str, out int key)
        {
            Console.WriteLine("================= Caesar Cipher Algorithm ==================");
            if (t == "Encrypt")
            {
                Console.Write("Enter plaintext: ");
            }
            else
            {
                Console.Write("Enter ciphertext: ");
            }

            str = Console.ReadLine();
            Console.Write("Enter key: ");
            key = int.Parse(Console.ReadLine());
        }
       
        public static void Encrypt(string plaintext, int key , Dictionary<char, int> myChars)
        {
            // Cipher(C) = (P + K) mod 26

            char[] cPlain = plaintext.ToCharArray();
            string result = "";

            for (int i = 0; i < cPlain.Length; i++)
            {

                if (char.IsWhiteSpace(cPlain[i]))
                {
                    Console.WriteLine(" ");
                }
                else if (myChars.ContainsKey(cPlain[i]))
                {
                    int index = (key + myChars[cPlain[i]]) % 26;
                    // return key by index
                    result += GetKeyFromValue(index, myChars);
                }
            }
           
            Console.Write("Cipher Text is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.ResetColor();
            Console.WriteLine("Have a nice day ...^-^...");
        }

        public static void Decrypt(string ciphertext, int key, Dictionary<char, int> myChars)
        {
            // Plain(P) = (C - K) mod 26
          
            char[] cCipher = ciphertext.ToCharArray();
            string result = "";

            for (int i = 0; i < cCipher.Length; i++)
            {

                if (char.IsWhiteSpace(cCipher[i]))
                {
                    Console.WriteLine(" ");
                }
                else if (myChars.ContainsKey(cCipher[i]))
                {
                    int index = (myChars[cCipher[i]] - key) % 26;

                    // return key by index
                    result += GetKeyFromValue(index, myChars);
                }
            }
            Console.Write("Plain Text is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
            Console.ResetColor();
            Console.WriteLine("Have a nice day ...^-^...");
        }

        public static char GetKeyFromValue(int valueVar, Dictionary<char, int> myChars)
        {
            foreach (char keyVar in myChars.Keys)
            {
                if (myChars[keyVar] == valueVar)
                {
                    return keyVar;
                }
            }
            return '\0'; // null [char]
        }
    }
}
