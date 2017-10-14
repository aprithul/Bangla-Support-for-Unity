using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

namespace Language
{
    public class UnicodeAnsiHandler
    {
        
        public Dictionary<string, string> unicode_ansi_dict;
        public Dictionary<string, string> compound_dict;
        public Dictionary<string, string> left_kars_dict;
        public Dictionary<string, string> right_kars_dict;
        public Dictionary<string, string> english_alphabet_dict;
        public List<char> unicode_characters = new List<char>();
       
        private string last_char = "";

        public UnicodeAnsiHandler()
        {
            prepare_unicode_to_ansi_dict();
        }


        public void prepare_unicode_to_ansi_dict()
        {
            unicode_ansi_dict = new Dictionary<string, string>();
            compound_dict = new Dictionary<string, string>();
            left_kars_dict = new Dictionary<string, string>();
            right_kars_dict = new Dictionary<string, string>();
            english_alphabet_dict = new Dictionary<string, string>();
            //var sr = new StreamReader(Application.dataPath + "/DB/bornomala.txt");
            //var fileContents = sr.ReadToEnd();
            //sr.Close();
            
            var englishAlphabet = @"
0 Ā
1 ā
2 Ă
3 ă
4 Ą
5 ą
6 Ć
7 ć
8 Ĉ
9 ĉ
A Ċ
B ċ
C Č
D č
E Ď
F ď
G Đ
H đ
I ē
J Ĕ
K ĕ
L Ė
M ė
N Ę
O ę
P Ě
Q ě
R Ĝ
S ĝ
T Ğ
U ğ
V Ġ
W ġ
X Ģ
Y ģ
Z Ĥ
a ĥ
b Ħ
c ħ
d Ĩ
e ĩ
f Ī
g ī
h Ĭ
i ĭ
j Į
k į
l İ
m ı
n Ĳ
o ĳ
p Ĵ
q ĵ
r Ķ
s ķ
t ĸ
u Ĺ
v ĺ
w Ļ
x ļ
y Ľ
z ľ
";

            var fileContents = @"অ A
আ Av
ই B
ঈ C
উ D
ঊ E
ঋ F
এ G
ঐ H
ও I
ঔ J
ক K
খ L
গ M
ঘ N
ঙ O
চ P
ছ Q
জ R
ঝ S
ঞ T
ট U
ঠ V
ড W
ঢ X
ণ Y
ত Z
থ _
দ `
ধ a
ন b
প c
ফ d
ব e
ভ f
ম g
য h
র i
ল j
শ k
ষ l
স m
হ n
ড় o
ঢ় p
য় q
ৎ r
ং s
ঃ t
ঁ u
. .
? ?
। |
! !
"" ""
$ ৳
: :
; ;
১ 1
২ 2
৩ 3
৪ 4
৫ 5
৬ 6
৭ 7
৮ 8
৯ 9
০ 0
* *
+ +
- -
% %
# #
( (
) )
= = 
< <
> >
= =
/ /
{ {
} }
[ [
] ]
' '
";

            var left_kars = @"
ি w
ে ‡
ৈ ˆ
";

            var right_kars = @"
া v
ী x
ু y
ূ ~
ৃ …
";
            var pl = char.ConvertFromUtf32(173);
            var compound_patterns = @"
ন্ট ›U
ক্ক °
ক্ট ±
ক্ত ³
ক্ম ´
ক্র µ
ক্ষ ¶
ক্স ·
গ্‌গ M&M
গ্‌দ M&`
গ্ধ »
ঙ্ক ¼
ঙ্গ ½
জ্জ ¾
জ্ঝ À
জ্ঞ Á
ঞ্চ Â
ঞ্ছ Ã
ঞ্জ Ä
ঞ্ঝ Å
ট্ট Æ
ড্ড Ç
ণ্ট È
ণ্ঠ É
ণ্ড Ê
ত্ত Ë
ত্ম Í
ত্র Î
দ্দ Ï
দ্ধ ×
দ্ব Ø
দ্ম Ù
ন্ঠ Ú
ন্ড Û
ন্ধ Ü
ন্স Ý
প্ট Þ
প্ত ß
প্প à
প্স á
ব্জ â
ব্দ ã
ব্ধ ä
ভ্র å
ম্ন æ
ম্ফ ç
ল্ক é
ল্গ ê
ল্ট ë
ল্ড ì
ল্প í
ল্‌ফ î
শু ï
শ্চ ð
শ্ছ ñ
ষ্ণ ò
ষ্ট ó
ষ্ঠ ô
ষ্ফ õ
স্খ ö
স্ট ÷
স্ন ø
স্ফ ù
হু û
হ্ন ý
ড়্গ ÿ
স্থ ¯’
ন্ত š—
ন্ন bœ
স্ক ¯‹
প্ল c−
ত্থ Ì
হ্ম þ
ন্ম b¥
ম্প m¤c
ন্থ bš’
স্ম ¯§
ন্দ ›`
";
                
            
            string[] lines = fileContents.Split('\n');
            foreach (string line in lines)
            {
                //line.Trim(' ');
                var line_parts = line.Split(' ');
                if (line_parts.Length == 2)
                {
                    line_parts[1] = line_parts[1].Substring(0, line_parts[1].Length - 1);
                    //print(line_parts[1].Length + " " + line_parts[1] + " " + line_parts[0]);

                    if (!unicode_ansi_dict.ContainsKey(line_parts[0]))
                        unicode_ansi_dict.Add(line_parts[0], line_parts[1]);
                }
            }

            lines = compound_patterns.Split('\n');
            foreach (string line in lines)
            {
                //line.Trim(' ');
                var line_parts = line.Split(' ');
                if (line_parts.Length == 2)
                {
                    line_parts[1] = line_parts[1].Substring(0, line_parts[1].Length - 1);
                    //print(line_parts[1].Length + " " + line_parts[1] + " " + line_parts[0]);

                    if (!compound_dict.ContainsKey(line_parts[0]))
                        compound_dict.Add(line_parts[0], line_parts[1]);
                }
            }

            lines = left_kars.Split('\n');
            foreach (string line in lines)
            {
                //line.Trim(' ');
                var line_parts = line.Split(' ');
                if (line_parts.Length == 2)
                {
                    line_parts[1] = line_parts[1].Substring(0, line_parts[1].Length - 1);
                    //print(line_parts[1].Length + " " + line_parts[1] + " " + line_parts[0]);

                    if (!left_kars_dict.ContainsKey(line_parts[0]))
                        left_kars_dict.Add(line_parts[0], line_parts[1]);
                }
            }

            lines = right_kars.Split('\n');
            foreach (string line in lines)
            {
                //line.Trim(' ');
                var line_parts = line.Split(' ');
                if (line_parts.Length == 2)
                {
                    line_parts[1] = line_parts[1].Substring(0, line_parts[1].Length - 1);
                    //print(line_parts[1].Length + " " + line_parts[1] + " " + line_parts[0]);

                    if (!right_kars_dict.ContainsKey(line_parts[0]))
                        right_kars_dict.Add(line_parts[0], line_parts[1]);
                }
            }

            lines = englishAlphabet.Split('\n');
            foreach (string line in lines)
            {
                //line.Trim(' ');
                var line_parts = line.Split(' ');
                if (line_parts.Length == 2)
                {
                    line_parts[1] = line_parts[1].Substring(0, line_parts[1].Length - 1);
                    //print(line_parts[1].Length + " " + line_parts[1] + " " + line_parts[0]);

                    if (!english_alphabet_dict.ContainsKey(line_parts[0]))
                        english_alphabet_dict.Add(line_parts[0], line_parts[1]);
                }
            }
        }

        public string get_ascii_word(string unicode_word)
        {
            
            var ascii_word = "";
            for (int _i = 0; _i < unicode_word.Length; _i++)
            {
                if(unicode_word[_i].ToString() == " ")
                {
                    ascii_word += " ";
                }
                else if (_i + 2 < unicode_word.Length && unicode_word[_i + 1].ToString() == "্")
                {
                    var key = unicode_word.Substring(_i, 3);
                    if (_i + 4 < unicode_word.Length && unicode_word[_i + 3].ToString() == "্")
                    {

                        var sub_str = unicode_word.Substring(_i, 5);
                        if (sub_str == "ক্ষ্ম")
                        {
                            last_char = "²";
                            ascii_word += last_char;
                        }
                        else if (sub_str == "জ্জ্ব")
                        {
                            last_char = "¾¡";
                            ascii_word += last_char;
                        }
                        else if(sub_str == "স্ত্র")
                        {
                            last_char = "¯¿";
                            ascii_word += last_char;
                        }
                        else if (sub_str == "ত্ত্ব")
                        {
                            last_char = "Ë¡";
                            ascii_word += last_char;
                        }
                        // tripple conjucts 
                        // do something special
                        _i += 4;
                    }
                    else if(unicode_word[_i].ToString() == "র" && _i+2 < unicode_word.Length)
                    {
                        last_char = unicode_ansi_dict[unicode_word[_i+2].ToString()] + "©";
                        ascii_word += last_char;
                        _i+=2;
                    }
                    else if (compound_dict.ContainsKey(key))
                    {
                        last_char = compound_dict[key];
                        ascii_word += last_char;
                        _i += 2;
                    }
                    else
                    {
                        switch (unicode_word[_i + 2].ToString())
                        {
                            case "ব":
                                last_char = unicode_ansi_dict[unicode_word[_i].ToString()] + "¦";
                                ascii_word += last_char;
                                _i += 2;
                                break;
                            case "র":
                                last_char = unicode_ansi_dict[unicode_word[_i].ToString()] + "Ö";
                                ascii_word += last_char;
                                _i += 2;
                                break;
                            case "য":
                                last_char = unicode_ansi_dict[unicode_word[_i].ToString()] + "¨";
                                ascii_word += last_char;
                                _i += 2;
                                break;
                        }
                    }
                }
                else if (_i + 1 < unicode_word.Length && unicode_word[_i + 1].ToString() == "়")
                {
                    switch(unicode_word[_i ].ToString())
                    {
                        case "য":
                            last_char = "q";
                            ascii_word += last_char;
                            break;
                        case "ড":
                            last_char = "o";
                            ascii_word += last_char;
                            break;
                        case "ঢ":
                            last_char = "p";
                            ascii_word += last_char;
                            break;
                    }
                    _i++;
                }
                else if (english_alphabet_dict.ContainsKey(unicode_word[_i].ToString()))
                {
                    last_char = english_alphabet_dict[unicode_word[_i].ToString()];
                    ascii_word += last_char;
                }
                else if (left_kars_dict.ContainsKey(unicode_word[_i].ToString()))
                {
                    ascii_word = ascii_word.Substring(0, ascii_word.Length - last_char.Length) + left_kars_dict[unicode_word[_i].ToString()] + last_char;
                }
                else if (right_kars_dict.ContainsKey(unicode_word[_i].ToString()))
                {
                    if(_i-1>=0 && unicode_word[_i-1].ToString() == "গ" && unicode_word[_i].ToString() == "ু")
                    {
                        last_char = "¸";
                        ascii_word = ascii_word.Substring(0, ascii_word.Length - 1) + last_char;
                    }
                    else if(_i - 1 >= 0 && unicode_word[_i - 1].ToString() == "র" && unicode_word[_i].ToString() == "ূ")
                    {
                        last_char = "iƒ";
                        ascii_word = ascii_word.Substring(0, ascii_word.Length - 1) + last_char;
                    }
                    else if (_i - 1 >= 0 && unicode_word[_i - 1].ToString() == "হ" && unicode_word[_i].ToString() == "ৃ")
                    {
                        last_char = "ü";
                        ascii_word = ascii_word.Substring(0, ascii_word.Length - 1) + last_char;
                    }
                    else
                        ascii_word += right_kars_dict[unicode_word[_i].ToString()];
                }
                else if(unicode_word[_i].ToString() ==  "ো")
                {
                    ascii_word = ascii_word.Substring(0, ascii_word.Length - last_char.Length) + "‡" + last_char + "v";
                }
                else if (unicode_word[_i].ToString() == "ৌ")
                {
                    ascii_word = ascii_word.Substring(0, ascii_word.Length - last_char.Length) + "‡" + last_char + "Š";
                }
                else if(unicode_word[_i].ToString() == "`")
                {
                    if(unicode_word.Length >_i+1 && unicode_word[_i+1].ToString() == "`")
                    {
                        if (_i - 1 >= 0 && unicode_word[_i - 1].ToString() == "ত")
                        {
                            last_char = "r";
                            ascii_word = ascii_word.Substring(0, ascii_word.Length - 3) + last_char;
                        }
                    }
                }
                else
                {
                    last_char = unicode_ansi_dict[unicode_word[_i].ToString()];
                    ascii_word += last_char;
                }
            }
            return ascii_word;
        }
    }
}