using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DES
    {
        public int[,] S1 = { { 14, 4, 13, 1, 2, 15, 11, 8, 3, 10, 6, 12, 5, 9, 0, 7 }, { 0, 15, 7, 4, 14, 2, 13, 1, 10, 6, 12, 11, 9, 5, 3, 8, }, { 4, 1, 14, 8, 13, 6, 2, 11, 15, 12, 9, 7, 3, 10, 5, 0 }, { 15, 12, 8, 2, 4, 9, 1, 7, 5, 11, 3, 14, 10, 0, 6, 13 } };
        public int[,] S2 = { { 15, 1, 8, 14, 6, 11, 3, 4, 9, 7, 2, 13, 12, 0, 5, 10 }, { 3, 13, 4, 7, 15, 2, 8, 14, 12, 0, 1, 10, 6, 9, 11, 5 }, { 0, 14, 7, 11, 10, 4, 13, 1, 5, 8, 12, 6, 9, 3, 2, 15 }, { 13, 8, 10, 1, 3, 15, 4, 2, 11, 6, 7, 12, 0, 5, 14, 9 } };
        public int[,] S3 = { { 10, 0, 9, 14, 6, 3, 15, 5, 1, 13, 12, 7, 11, 4, 2, 8 }, { 13, 7, 0, 9, 3, 4, 6, 10, 2, 8, 5, 14, 12, 11, 15, 1, }, { 13, 6, 4, 9, 8, 15, 3, 0, 11, 1, 2, 12, 5, 10, 14, 7 }, { 1, 10, 13, 0, 6, 9, 8, 7, 4, 15, 14, 3, 11, 5, 2, 12 } };
        public int[,] S4 = { { 7, 13, 14, 3, 0, 6, 9, 10, 1, 2, 8, 5, 11, 12, 4, 15 }, { 13, 8, 11, 5, 6, 15, 0, 3, 4, 7, 2, 12, 1, 10, 14, 9 }, { 10, 6, 9, 0, 12, 11, 7, 13, 15, 1, 3, 14, 5, 2, 8, 4 }, { 3, 15, 0, 6, 10, 1, 13, 8, 9, 4, 5, 11, 12, 7, 2, 14 } };
        public int[,] S5 = { { 2, 12, 4, 1, 7, 10, 11, 6, 8, 5, 3, 15, 13, 0, 14, 9 }, { 14, 11, 2, 12, 4, 7, 13, 1, 5, 0, 15, 10, 3, 9, 8, 6 }, { 4, 2, 1, 11, 10, 13, 7, 8, 15, 9, 12, 5, 6, 3, 0, 14 }, { 11, 8, 12, 7, 1, 14, 2, 13, 6, 15, 0, 9, 10, 4, 5, 3 } };
        public int[,] S6 = { { 12, 1, 10, 15, 9, 2, 6, 8, 0, 13, 3, 4, 14, 7, 5, 11 }, { 10, 15, 4, 2, 7, 12, 9, 5, 6, 1, 13, 14, 0, 11, 3, 8 }, { 9, 14, 15, 5, 2, 8, 12, 3, 7, 0, 4, 10, 1, 13, 11, 6 }, { 4, 3, 2, 12, 9, 5, 15, 10, 11, 14, 1, 7, 6, 0, 8, 13 } };
        public int[,] S7 = { { 4, 11, 2, 14, 15, 0, 8, 13, 3, 12, 9, 7, 5, 10, 6, 1 }, { 13, 0, 11, 7, 4, 9, 1, 10, 14, 3, 5, 12, 2, 15, 8, 6 }, { 1, 4, 11, 13, 12, 3, 7, 14, 10, 15, 6, 8, 0, 5, 9, 2 }, { 6, 11, 13, 8, 1, 4, 10, 7, 9, 5, 0, 15, 14, 2, 3, 12 } };
        public int[,] S8 = { { 13, 2, 8, 4, 6, 15, 11, 1, 10, 9, 3, 14, 5, 0, 12, 7 }, { 1, 15, 13, 8, 10, 3, 7, 4, 12, 5, 6, 11, 0, 14, 9, 2 }, { 7, 11, 4, 1, 9, 12, 14, 2, 0, 6, 10, 13, 15, 3, 5, 8 }, { 2, 1, 14, 7, 4, 10, 8, 13, 15, 12, 9, 0, 3, 5, 6, 11 } };

        public bool[,] SubKeyC;
        public bool[,] SubKeyD;
        public bool[,] SubKey;
        public DES()
        {
            SubKeyC = new bool[16, 28];
            SubKeyD = new bool[16, 28];
            SubKey = new bool[16, 48];           
        }

        public string FreeSpace(string input)
        {
            string Ans="";
            for (int i = 0; i < input.Length; i++)
                if (input[i] != ' ' && input[i] != '\n')
                    Ans += input[i];                              
            return Ans;
        }      
        public bool[] DesToBinery(int input)
        {
            bool[] Ans = new bool[4];
            for (int i = 4 - 1; i >= 0; i--)
                if (input - pow2(i) >= 0)
                {
                    Ans[3-i] = true;
                    input -= pow2(i);
                }
            return Ans;
        }
        public int BineryToDes(bool[] input)
        {
            input = ReverseBinery(input);
            int Ans = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i])
                    Ans += pow2(i);
            }
            return Ans;
        }
        public bool[] HexToBinery(char input)
        {
            int Ans;
            if (input == 'a' || input == 'A')
                Ans = 10;
            else if (input == 'b' || input == 'B')
                Ans = 11;
            else if (input == 'c' || input == 'C')
                Ans = 12;
            else if (input == 'd' || input == 'D')
                Ans = 13;
            else if (input == 'e' || input == 'E')
                Ans = 14;
            else if (input == 'f' || input == 'F')
                Ans = 15;
            else
                Ans = int.Parse(input+"");
            return DesToBinery(Ans);
        }
        public bool[] GetBinery(string input)
        {
            bool[] Ans = new bool[64];
            for (int i = 0; i < input.Length; i++)
            {
                bool[] temp = HexToBinery(input[i]);
                for (int j = 0; j < 4; j++)
                    Ans[i*4+j] = temp[j];             
            }
            return Ans;
        }
        public char BineryToHex(bool[] input)
        {
            int temp = BineryToDes(input);
            if (temp == 10)
                return 'A';
            if (temp == 11)
                return 'B';
            if (temp == 12)
                return 'C';
            if (temp == 13)
                return 'D';
            if (temp == 14)
                return 'E';
            if (temp == 15)
                return 'F';
            return char.Parse(temp + "");
        }
        public string Encryption(string plaintext, string key)
        {
            key = FreeSpace(key);
            plaintext = FreeSpace(plaintext);
            if (plaintext.Length!=16||key.Length!=16)
            {
                System.Windows.Forms.MessageBox.Show("wrong input !");
                return "";
            }
            bool[] PlainText64bity = GetBinery(plaintext);
            bool[] key64bity = GetBinery(key);
            CreateSubkeys(PermutedChoice1(key64bity));
            PlainText64bity=InitialPermutation(PlainText64bity);
            bool[] LeftPlain = GetPart(PlainText64bity, true);
            bool[] RightPlain = GetPart(PlainText64bity, false);
            for (int i = 1; i <= 16; i++)
            {
                var temp = LeftPlain;
                LeftPlain = RightPlain;
                RightPlain = X_OR(temp, Ffunction(RightPlain, GetSubKey(i)));
            }
// create string subkey
            string Str1 = "";
            for (int i = 0; i < 16; i++)
            {
                Str1 += i + 1 + " : " + GetString(GetSubKey(i + 1)) + '\n' ;                
            }
            System.Windows.Forms.MessageBox.Show(Str1);
            return GetString(PermutationLast(Incorporation(RightPlain,LeftPlain)));
        }

        public string Decryption(string ciphertext, string key)
        {            
            key = FreeSpace(key);
            ciphertext = FreeSpace(ciphertext);
            if (ciphertext.Length != 16 || key.Length != 16)
            {
                System.Windows.Forms.MessageBox.Show("wrong input !");
                return "";
            }
            bool[] ciphertext64bity = GetBinery(ciphertext);
            bool[] key64bity = GetBinery(key);
            CreateSubkeys(PermutedChoice1(key64bity));
            ciphertext64bity = PermutationLastR(ciphertext64bity);
            bool[] LeftPlain = GetPart(ciphertext64bity, false);
            bool[] RightPlain = GetPart(ciphertext64bity, true);
            for (int i = 16; i >=1; i--)
            {
                var temp = RightPlain;
                RightPlain=LeftPlain;
                LeftPlain = X_OR(temp, Ffunction(LeftPlain, GetSubKey(i)));
            }
            return GetString(InitialPermutationR(Incorporation(LeftPlain,RightPlain )));            
        }
        public string GetString(bool[] input)
        {
            string tempAns = "";
            string Ans = "";
            bool[] temp = new bool[4];
            for (int i = 0; i < input.Length/4; i++)
            {
                for (int j = 0; j < 4; j++)
                    temp[j] = input[i * 4 + j];
                tempAns += BineryToHex(temp);
            }
            for (int i = 0; i < input.Length / 4; i++)
            {
                if (i % 2 == 1)
                    Ans += tempAns[i] + " ";
                else
                    Ans += tempAns[i] + "";
            }
            return Ans;
        }
        
        public bool[] Extension32To48(bool[] input)
        {
            bool[] Ans = new bool[48];
            Ans[0] = input[31];
            Ans[47] = input[0];
            int k = 0;
            for (int i = 1; i < 48; i++)
            {
                if (i % 6 != 0 && i % 6 != 5)
                    Ans[i] = input[k++];
            }
            for (int i = 1; i < 47; i++)
            {
                if (i % 6 == 0)
                    Ans[i] = Ans[i - 2];
                if (i % 6 == 5)
                    Ans[i] = Ans[i + 2];
            }
            return Ans;
        }
        public int pow2(int index)
        {
            int Ans = 1;
            for (int i = 0; i < index; i++)
                Ans *= 2;
            return Ans;
        }
        public bool[] GetSubKey(int index)
        {
            bool[] Ans = new bool[48];
            for (int i = 0; i < 48; i++)
                Ans[i] = SubKey[index-1, i];
            return Ans;
        }
        public void SetSubKey(bool[] input, int index)
        {
            for (int i = 0; i < input.Length; i++)
                SubKey[index, i] = input[i];
        }
        public bool[] GetSubKeyC(int index)
        {
            bool[] Ans=new bool[28];
            for (int i = 0; i < 28; i++)            
                Ans[i] = SubKeyC[index, i];
            return Ans;
        }

        public bool[] GetSubKeyD(int index)
        {
            bool[] Ans = new bool[28];
            for (int i = 0; i < 28; i++)
                Ans[i] = SubKeyD[index, i];
            return Ans;
        }
        public void SetSubKeyC(bool[] input, int index)
        {
            for (int i = 0; i < 28; i++)
                SubKeyC[index, i] = input[i];            
        }
        public void SetSubKeyD(bool[] input, int index)
        {
            for (int i = 0; i < 28; i++)
                SubKeyD[index, i] = input[i];
        }
        public void CreateSubkeys(bool[] input)
        {         
            SetSubKeyC(RotateLeftShift(GetPart(input, true)),0);
            SetSubKeyD(RotateLeftShift(GetPart(input, false)),0);
            for (int i = 1; i < 16; i++)
            {
                if (i==1 ||i==8 ||i==15 )
	            {
                    SetSubKeyC(RotateLeftShift(GetSubKeyC(i - 1)), i);
                    SetSubKeyD(RotateLeftShift(GetSubKeyD(i-1)),i);
	            }
                else
	            {
                    SetSubKeyC(RotateLeftShift(RotateLeftShift(GetSubKeyC(i-1))),i);
                    SetSubKeyD(RotateLeftShift(RotateLeftShift(GetSubKeyD(i-1))),i);
	            }
            }
            for (int i = 0; i < 16; i++)
                SetSubKey(PermutedChoice2(Incorporation(GetSubKeyC(i), GetSubKeyD(i))), i);           
        }
     
     
        public bool[] X_OR(bool[] input01, bool[] input02)
        {
            bool[] Ans = new bool[input01.Length];
            for (int i = 0; i < input01.Length; i++)
            {
                if (input01[i] == input02[i])
                    Ans[i] = false;
                else
                    Ans[i] = true;
            }
            return Ans;
        }
        public bool[] GetPart(bool[] input, bool IsLeft)
        {
            bool[] Ans = new bool[input.Length / 2];
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (IsLeft)
                    Ans[i] =input[i];
                else
                    Ans[i] = input[input.Length / 2 + i];
            }
            return Ans;
        }
        public bool[] Incorporation(bool[] input01, bool[] input02)
        {
            bool[] Ans = new bool[input01.Length + input02.Length];
            for (int i = 0; i < input01.Length; i++)
                Ans[i] = input01[i];
            for (int i = 0; i < input02.Length; i++)
                Ans[input01.Length+i] = input02[i];
            return Ans;
        }
        public bool[] GetBbinery(bool[,] input, int index)
        {
            bool[] Ans ={input[index-1,1],input[index-1,2],input[index-1,3],input[index-1,4]};               
            return Ans;
        }
        public int GetBIndex(bool[,] input, int index)
        {
            bool[] Ans = new bool[2];
            Ans[0] = input[index-1, 0];
            Ans[1] = input[index-1,5];
            return BineryToDes(Ans);            
        }
        public bool[] ReverseBinery(bool[] input)
        {
            bool[] Ans = new bool[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                Ans[i] = input[input.Length - i - 1];
            }
            return Ans;
        }


        public bool[] Ffunction(bool[] input01, bool[] input02)
        {
            bool[]RightPart=Extension32To48(input01);
            RightPart = X_OR(RightPart, input02);
            bool[,] B = new bool[8, 6];
            for (int i = 0; i < 48; i++)           
               B[i/6,i%6]= RightPart[i];
            bool[] XB1 = DesToBinery(S1[GetBIndex(B, 1), BineryToDes(GetBbinery(B, 1))]);
            bool[] XB2 = DesToBinery(S2[GetBIndex(B, 2), BineryToDes(GetBbinery(B, 2))]);
            bool[] XB3 = DesToBinery(S3[GetBIndex(B, 3), BineryToDes(GetBbinery(B, 3))]);
            bool[] XB4 = DesToBinery(S4[GetBIndex(B, 4), BineryToDes(GetBbinery(B, 4))]);
            bool[] XB5 = DesToBinery(S5[GetBIndex(B, 5), BineryToDes(GetBbinery(B, 5))]);
            bool[] XB6 = DesToBinery(S6[GetBIndex(B, 6), BineryToDes(GetBbinery(B, 6))]);
            bool[] XB7 = DesToBinery(S7[GetBIndex(B, 7), BineryToDes(GetBbinery(B, 7))]);
            bool[] XB8 = DesToBinery(S8[ GetBIndex(B, 8),BineryToDes(GetBbinery(B,8))]);
            return PermutationP(Incorporation(Incorporation(Incorporation(XB1, XB2), Incorporation(XB3, XB4)), Incorporation(Incorporation(XB5, XB6), Incorporation(XB7, XB8))));
        }       
        public bool[] InitialPermutation(bool[] input)
        {
            bool[] Ans=new bool[64];
            int i=0;
            Ans[i++] = input[58-1];
            Ans[i++] = input[50-1];
            Ans[i++] = input[42-1];
            Ans[i++] = input[34-1];
            Ans[i++] = input[26-1];
            Ans[i++] = input[18-1];
            Ans[i++] = input[10-1];
            Ans[i++] = input[2-1];
            Ans[i++] = input[60-1];
            Ans[i++] = input[52-1];
            Ans[i++] = input[44-1];
            Ans[i++] = input[36-1];
            Ans[i++] = input[28-1];
            Ans[i++] = input[20-1];
            Ans[i++] = input[12-1];
            Ans[i++] = input[4-1];
            Ans[i++] = input[62-1];
            Ans[i++] = input[54-1];
            Ans[i++] = input[46-1];
            Ans[i++] = input[38-1];
            Ans[i++] = input[30-1];
            Ans[i++] = input[22-1];
            Ans[i++] = input[14-1];
            Ans[i++] = input[6-1];
            Ans[i++] = input[64-1];
            Ans[i++] = input[56-1];
            Ans[i++] = input[48-1];
            Ans[i++] = input[40-1];
            Ans[i++] = input[32-1];
            Ans[i++] = input[24-1];
            Ans[i++] = input[16-1];
            Ans[i++] = input[8-1];
            Ans[i++] = input[57-1];
            Ans[i++] = input[49-1];
            Ans[i++] = input[41-1];
            Ans[i++] = input[33-1];
            Ans[i++] = input[25-1];
            Ans[i++] = input[17-1];
            Ans[i++] = input[9-1];
            Ans[i++] = input[1-1];
            Ans[i++] = input[59-1];
            Ans[i++] = input[51-1];
            Ans[i++] = input[43-1];
            Ans[i++] = input[35-1];
            Ans[i++] = input[27-1];
            Ans[i++] = input[19-1];
            Ans[i++] = input[11-1];
            Ans[i++] = input[3-1];
            Ans[i++] = input[61-1];
            Ans[i++] = input[53-1];
            Ans[i++] = input[45-1];
            Ans[i++] = input[37-1];
            Ans[i++] = input[29-1];
            Ans[i++] = input[21-1];
            Ans[i++] = input[13-1];
            Ans[i++] = input[5-1];
            Ans[i++] = input[63-1];
            Ans[i++] = input[55-1];
            Ans[i++] = input[47-1];
            Ans[i++] = input[39-1];
            Ans[i++] = input[31-1];
            Ans[i++] = input[23-1];
            Ans[i++] = input[15-1];
            Ans[i++] = input[7-1];
            return Ans;
        }
        public bool[] PermutedChoice1(bool[] input)
        {
            bool[] Ans=new bool[56];
            int i=0;
            Ans[i++] = input[57-1];
            Ans[i++] = input[49-1];
            Ans[i++] = input[41-1];
            Ans[i++] = input[33-1];
            Ans[i++] = input[25-1];
            Ans[i++] = input[17-1];
            Ans[i++] = input[9-1];
            Ans[i++] = input[1-1];
            Ans[i++] = input[58-1];
            Ans[i++] = input[50-1];
            Ans[i++] = input[42-1];
            Ans[i++] = input[34-1];
            Ans[i++] = input[26-1];
            Ans[i++] = input[18-1];
            Ans[i++] = input[10-1];
            Ans[i++] = input[2-1];
            Ans[i++] = input[59-1];
            Ans[i++] = input[51-1];
            Ans[i++] = input[43-1];
            Ans[i++] = input[35-1];
            Ans[i++] = input[27-1];
            Ans[i++] = input[19-1];
            Ans[i++] = input[11-1];
            Ans[i++] = input[3-1];
            Ans[i++] = input[60-1];
            Ans[i++] = input[52-1];
            Ans[i++] = input[44-1];
            Ans[i++] = input[36-1];
            Ans[i++] = input[63-1];
            Ans[i++] = input[55-1];
            Ans[i++] = input[47-1];
            Ans[i++] = input[39-1];
            Ans[i++] = input[31-1];
            Ans[i++] = input[23-1];
            Ans[i++] = input[15-1];
            Ans[i++] = input[7-1];
            Ans[i++] = input[62-1];
            Ans[i++] = input[54-1];
            Ans[i++] = input[46-1];
            Ans[i++] = input[38-1];
            Ans[i++] = input[30-1];
            Ans[i++] = input[22-1];
            Ans[i++] = input[14-1];
            Ans[i++] = input[6-1];
            Ans[i++] = input[61-1];
            Ans[i++] = input[53-1];
            Ans[i++] = input[45-1];
            Ans[i++] = input[37-1];
            Ans[i++] = input[29-1];
            Ans[i++] = input[21-1];
            Ans[i++] = input[13-1];
            Ans[i++] = input[5-1];
            Ans[i++] = input[28-1];
            Ans[i++] = input[20-1];
            Ans[i++] = input[12-1];
            Ans[i++] = input[4-1];
            return Ans;
        }
        public bool[] PermutedChoice2(bool[] input)
        {
            bool[] Ans=new bool[48];
            int i = 0;
            Ans[i++] = input[14-1];
            Ans[i++] = input[17 - 1];
            Ans[i++] = input[11-1];
            Ans[i++] = input[24-1];
            Ans[i++] = input[1-1];
            Ans[i++] = input[5-1];
            Ans[i++] = input[3-1];
            Ans[i++] = input[28-1];
            Ans[i++] = input[15-1];
            Ans[i++] = input[6-1];
            Ans[i++] = input[21-1];
            Ans[i++] = input[10-1];
            Ans[i++] = input[23-1];
            Ans[i++] = input[19-1];
            Ans[i++] = input[12-1];
            Ans[i++] = input[4-1];
            Ans[i++] = input[26-1];
            Ans[i++] = input[8-1];
            Ans[i++] = input[16-1];
            Ans[i++] = input[7-1];
            Ans[i++] = input[27-1];
            Ans[i++] = input[20-1];
            Ans[i++] = input[13-1];
            Ans[i++] = input[2-1];
            Ans[i++] = input[41-1];
            Ans[i++] = input[52-1];
            Ans[i++] = input[31-1];
            Ans[i++] = input[37-1];
            Ans[i++] = input[47-1];
            Ans[i++] = input[55-1];
            Ans[i++] = input[30-1];
            Ans[i++] = input[40-1];
            Ans[i++] = input[51-1];
            Ans[i++] = input[45-1];
            Ans[i++] = input[33-1];
            Ans[i++] = input[48-1];
            Ans[i++] = input[44-1];
            Ans[i++] = input[49-1];
            Ans[i++] = input[39-1];
            Ans[i++] = input[56-1];
            Ans[i++] = input[34-1];
            Ans[i++] = input[53-1];
            Ans[i++] = input[46-1];
            Ans[i++] = input[42-1];
            Ans[i++] = input[50-1];
            Ans[i++] = input[36-1];
            Ans[i++] = input[29-1];
            Ans[i++] = input[32-1];
            return Ans;
        }
        public bool[] PermutationP(bool[] input)
        {
            bool[] Ans = new bool[32];
            int i = 0;
            Ans[i++] = input[16-1];
            Ans[i++] = input[7-1];
            Ans[i++] = input[20-1];
            Ans[i++] = input[21-1];
            Ans[i++] = input[29-1];
            Ans[i++] = input[12-1];
            Ans[i++] = input[28-1];
            Ans[i++] = input[17-1];
            Ans[i++] = input[1-1];
            Ans[i++] = input[15-1];
            Ans[i++] = input[23-1];
            Ans[i++] = input[26-1];
            Ans[i++] = input[5-1];
            Ans[i++] = input[18-1];
            Ans[i++] = input[31-1];
            Ans[i++] = input[10-1];
            Ans[i++] = input[2-1];
            Ans[i++] = input[8-1];
            Ans[i++] = input[24-1];
            Ans[i++] = input[14-1];
            Ans[i++] = input[32-1];
            Ans[i++] = input[27-1];
            Ans[i++] = input[3-1];
            Ans[i++] = input[9-1];
            Ans[i++] = input[19-1];
            Ans[i++] = input[13-1];
            Ans[i++] = input[30-1];
            Ans[i++] = input[6-1];
            Ans[i++] = input[22-1];
            Ans[i++] = input[11-1];
            Ans[i++] = input[4-1];
            Ans[i++] = input[25-1];
            return Ans;
        }
        public bool[] PermutationLast(bool[] input)
        {
            bool[] Ans = new bool[64];
            int i = 0;
            Ans[i++] = input[40-1];
            Ans[i++] = input[8-1];
            Ans[i++] = input[48-1];
            Ans[i++] = input[16-1];
            Ans[i++] = input[56-1];
            Ans[i++] = input[24-1];
            Ans[i++] = input[64-1];
            Ans[i++] = input[32-1];
            Ans[i++] = input[39-1];
            Ans[i++] = input[7-1];
            Ans[i++] = input[47-1];
            Ans[i++] = input[15-1];
            Ans[i++] = input[55-1];
            Ans[i++] = input[23-1];
            Ans[i++] = input[63-1];
            Ans[i++] = input[31-1];
            Ans[i++] = input[38-1];
            Ans[i++] = input[6-1];
            Ans[i++] = input[46-1];
            Ans[i++] = input[14-1];
            Ans[i++] = input[54-1];
            Ans[i++] = input[22-1];
            Ans[i++] = input[62-1];
            Ans[i++] = input[30-1];
            Ans[i++] = input[37-1];
            Ans[i++] = input[5-1];
            Ans[i++] = input[45-1];
            Ans[i++] = input[13-1];
            Ans[i++] = input[53-1];
            Ans[i++] = input[21-1];
            Ans[i++] = input[61-1];
            Ans[i++] = input[29-1];
            Ans[i++] = input[36-1];
            Ans[i++] = input[4-1];
            Ans[i++] = input[44-1];
            Ans[i++] = input[12-1];
            Ans[i++] = input[52-1];
            Ans[i++] = input[20-1];
            Ans[i++] = input[60-1];
            Ans[i++] = input[28-1];
            Ans[i++] = input[35-1];
            Ans[i++] = input[3-1];
            Ans[i++] = input[43-1];
            Ans[i++] = input[11-1];
            Ans[i++] = input[51-1];
            Ans[i++] = input[19-1];
            Ans[i++] = input[59-1];
            Ans[i++] = input[27-1];
            Ans[i++] = input[34-1];
            Ans[i++] = input[2-1];
            Ans[i++] = input[42-1];
            Ans[i++] = input[10-1];
            Ans[i++] = input[50-1];
            Ans[i++] = input[18-1];
            Ans[i++] = input[58-1];
            Ans[i++] = input[26-1];
            Ans[i++] = input[33-1];
            Ans[i++] = input[1-1];
            Ans[i++] = input[41-1];
            Ans[i++] = input[9-1];
            Ans[i++] = input[49-1];
            Ans[i++] = input[17-1];
            Ans[i++] = input[57-1];
            Ans[i++] = input[25-1];
            return Ans;
        }

        public bool[] InitialPermutationR(bool[] input)
        {
            bool[] Ans = new bool[64];
            int i = 0;
            Ans[i++] = input[58 - 1];
            Ans[i++] = input[50 - 1];
            Ans[i++] = input[42 - 1];
            Ans[i++] = input[34 - 1];
            Ans[i++] = input[26 - 1];
            Ans[i++] = input[18 - 1];
            Ans[i++] = input[10 - 1];
            Ans[i++] = input[2 - 1];
            Ans[i++] = input[60 - 1];
            Ans[i++] = input[52 - 1];
            Ans[i++] = input[44 - 1];
            Ans[i++] = input[36 - 1];
            Ans[i++] = input[28 - 1];
            Ans[i++] = input[20 - 1];
            Ans[i++] = input[12 - 1];
            Ans[i++] = input[4 - 1];
            Ans[i++] = input[62 - 1];
            Ans[i++] = input[54 - 1];
            Ans[i++] = input[46 - 1];
            Ans[i++] = input[38 - 1];
            Ans[i++] = input[30 - 1];
            Ans[i++] = input[22 - 1];
            Ans[i++] = input[14 - 1];
            Ans[i++] = input[6 - 1];
            Ans[i++] = input[64 - 1];
            Ans[i++] = input[56 - 1];
            Ans[i++] = input[48 - 1];
            Ans[i++] = input[40 - 1];
            Ans[i++] = input[32 - 1];
            Ans[i++] = input[24 - 1];
            Ans[i++] = input[16 - 1];
            Ans[i++] = input[8 - 1];
            Ans[i++] = input[57 - 1];
            Ans[i++] = input[49 - 1];
            Ans[i++] = input[41 - 1];
            Ans[i++] = input[33 - 1];
            Ans[i++] = input[25 - 1];
            Ans[i++] = input[17 - 1];
            Ans[i++] = input[9 - 1];
            Ans[i++] = input[1 - 1];
            Ans[i++] = input[59 - 1];
            Ans[i++] = input[51 - 1];
            Ans[i++] = input[43 - 1];
            Ans[i++] = input[35 - 1];
            Ans[i++] = input[27 - 1];
            Ans[i++] = input[19 - 1];
            Ans[i++] = input[11 - 1];
            Ans[i++] = input[3 - 1];
            Ans[i++] = input[61 - 1];
            Ans[i++] = input[53 - 1];
            Ans[i++] = input[45 - 1];
            Ans[i++] = input[37 - 1];
            Ans[i++] = input[29 - 1];
            Ans[i++] = input[21 - 1];
            Ans[i++] = input[13 - 1];
            Ans[i++] = input[5 - 1];
            Ans[i++] = input[63 - 1];
            Ans[i++] = input[55 - 1];
            Ans[i++] = input[47 - 1];
            Ans[i++] = input[39 - 1];
            Ans[i++] = input[31 - 1];
            Ans[i++] = input[23 - 1];
            Ans[i++] = input[15 - 1];
            Ans[i++] = input[7 - 1];
            return Ans;
        }
       
        public bool[] PermutationLastR(bool[] input)
        {
            bool[] Ans = new bool[64];
            int i = 0;
            Ans[40 - 1] = input[i++];
            Ans[8 - 1] = input[i++];
            Ans[48 - 1] = input[i++];
            Ans[16 - 1] = input[i++];
            Ans[56 - 1] = input[i++];
            Ans[24 - 1] = input[i++];
            Ans[64 - 1] = input[i++];
            Ans[32 - 1] = input[i++];
            Ans[39 - 1] = input[i++];
            Ans[7 - 1] = input[i++];
            Ans[47 - 1] = input[i++];
            Ans[15 - 1] = input[i++];
            Ans[55 - 1] = input[i++];
            Ans[23 - 1] = input[i++];
            Ans[63 - 1] = input[i++];
            Ans[31 - 1] = input[i++];
            Ans[38 - 1] = input[i++];
            Ans[6 - 1] = input[i++];
            Ans[46 - 1] = input[i++];
            Ans[14 - 1] = input[i++];
            Ans[54 - 1] = input[i++];
            Ans[22 - 1] = input[i++];
            Ans[62 - 1] = input[i++];
            Ans[30 - 1] = input[i++];
            Ans[37 - 1] = input[i++];
            Ans[5 - 1] = input[i++];
            Ans[45 - 1] = input[i++];
            Ans[13 - 1] = input[i++];
            Ans[53 - 1] = input[i++];
            Ans[21 - 1] = input[i++];
            Ans[61 - 1] = input[i++];
            Ans[29 - 1] = input[i++];
            Ans[36 - 1] = input[i++];
            Ans[4 - 1] = input[i++];
            Ans[44 - 1] = input[i++];
            Ans[12 - 1] = input[i++];
            Ans[52 - 1] = input[i++];
            Ans[20 - 1] = input[i++];
            Ans[60 - 1] = input[i++];
            Ans[28 - 1] = input[i++];
            Ans[35 - 1] = input[i++];
            Ans[3 - 1] = input[i++];
            Ans[43 - 1] = input[i++];
            Ans[11 - 1] = input[i++];
            Ans[51 - 1] = input[i++];
            Ans[19 - 1] = input[i++];
            Ans[59 - 1] = input[i++];
            Ans[27 - 1] = input[i++];
            Ans[34 - 1] = input[i++];
            Ans[2 - 1] = input[i++];
            Ans[42 - 1] = input[i++];
            Ans[10 - 1] = input[i++];
            Ans[50 - 1] = input[i++];
            Ans[18 - 1] = input[i++];
            Ans[58 - 1] = input[i++];
            Ans[26 - 1] = input[i++];
            Ans[33 - 1] = input[i++];
            Ans[1 - 1] = input[i++];
            Ans[41 - 1] = input[i++];
            Ans[9 - 1] = input[i++];
            Ans[49 - 1] = input[i++];
            Ans[17 - 1] = input[i++];
            Ans[57 - 1] = input[i++];
            Ans[25 - 1] = input[i++];
            return Ans;
        }
         
        public bool[] RotateLeftShift(bool[] input)
        {
            bool[] Ans = new bool[input.Length];
            int i = 0;
            for (; i < input.Length-1; i++)
                Ans[i] = input[i+1];
            Ans[i] = input[0];
            return Ans;
        }
    }
}
