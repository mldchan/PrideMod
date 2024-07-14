using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PrideMod.Features.MSCOwOify
{
    [Flags]
    internal enum UwuifyFlag
    {
        None = 0,
        Smiley = 1,
        Yu = 2,
        Stutter = 4,
        Nouwu = 8
    }

    internal class Uwuifier
    {
        private static readonly string[] Smileys = new string[]
        {
            "(ᵘʷᵘ)",
            "(ᵘﻌᵘ)",
            "(◡ ω ◡)",
            "(◡ ꒳ ◡)",
            "(◡ w ◡)",
            "(◡ ሠ ◡)",
            "(˘ω˘)",
            "(⑅˘꒳˘)",
            "(˘ᵕ˘)",
            "(˘ሠ˘)",
            "(˘³˘)",
            "(˘ε˘)",
            "(˘˘˘)",
            "( ᴜ ω ᴜ )",
            "(„ᵕᴗᵕ„)",
            "(ㅅꈍ ˘ ꈍ)",
            "(⑅˘꒳˘)",
            "( ｡ᵘ ᵕ ᵘ ｡)",
            "( ᵘ ꒳ ᵘ ✼)",
            "( ˘ᴗ˘ )",
            "(ᵕᴗ ᵕ⁎)",
            "*:･ﾟ✧(ꈍᴗꈍ)✧･ﾟ:*",
            "*˚*(ꈍ ω ꈍ).₊̣̇.",
            "(。U ω U。)",
            "(U ᵕ U❁)",
            "(U ﹏ U)",
            "(◦ᵕ ˘ ᵕ◦)",
            "ღ(U꒳Uღ)",
            "♥(。U ω U。)",
            "– ̗̀ (ᵕ꒳ᵕ) ̖́-",
            "( ͡U ω ͡U )",
            "( ͡o ᵕ ͡o )",
            "( ͡o ꒳ ͡o )",
            "( ˊ.ᴗˋ )",
            "(ᴜ‿ᴜ✿)",
            "~(˘▾˘~)",
            "(｡ᴜ‿‿ᴜ｡)",
            "uwu",
            "owo"
        };

        private static readonly Dictionary<char, char> UwuTranslation = new Dictionary<char, char>
        {
            {'r', 'w'},
            {'l', 'w'},
            {'R', 'W'},
            {'L', 'W'}
        };

        private static readonly Dictionary<char, string> YuTranslation = new Dictionary<char, string>
        {
            {'u', "yu"},
            {'U', "yU"}
        };

        private static readonly Regex ErReplace = new Regex(@"(\b\w{2,})er\b", RegexOptions.IgnoreCase);
        private static readonly Regex AngleBrackets = new Regex(@"<[^>]*>");

        private static string DoYu(string entry)
        {
            var final = new List<string>();
            foreach (var word in entry.Split(' '))
            {
                if (!string.IsNullOrEmpty(word))
                    final.Add(word[0] + new string(word.Substring(1).Select(c => YuTranslation.ContainsKey(c) ? YuTranslation[c][0] : c).ToArray()));
                else
                    final.Add(" ");
            }
            return string.Join(" ", final.ToArray());
        }

        private static string DoUwu(string entry)
        {
            var regexed = ErReplace.Replace(entry, m => m.Groups[1].Value + "a");
            var translated = new string(regexed.Select(c => UwuTranslation.ContainsKey(c) ? UwuTranslation[c] : c).ToArray());
            return translated;
        }

        private static string DoSmiley(string entry)
        {
            var final = new List<string>();
            foreach (var word in entry.Split(' '))
            {
                if (word.EndsWith(".", StringComparison.Ordinal) || word.EndsWith("?", StringComparison.Ordinal) || word.EndsWith("!", StringComparison.Ordinal))
                    final.Add(word + " " + Smileys[new Random().Next(Smileys.Length)]);
                else
                    final.Add(word);
            }
            return string.Join(" ", final.ToArray());
        }

        private static string DoStutter(string entry, int stutterEveryNthWord = 4)
        {
            if (stutterEveryNthWord < 1)
                throw new ArgumentException(string.Format("stutterEveryNthWord must be above 0; passed {0}", stutterEveryNthWord));

            var listofstr = Regex.Split(entry, @"(\s+)");
            var result = new List<string>();
            var wordsSinceLastStutter = 0;
            foreach (var word in listofstr)
            {
                if (!string.IsNullOrEmpty(word) && !string.IsNullOrEmpty(word))
                {
                    if (wordsSinceLastStutter % stutterEveryNthWord == 0)
                        result.Add(string.Format("{0}-{1}", word[0], word));
                    else
                        result.Add(word);
                    wordsSinceLastStutter++;
                }
            }
            return string.Concat(result.ToArray());
        }

        public static string Uwuify(string entry, UwuifyFlag flags = UwuifyFlag.None)
        {
            if (!MscOwOify.owoifier.GetValue()) return entry;

            if (string.IsNullOrEmpty(entry))
                return entry;

            // Store the content between angle brackets
            var matches = new List<string>();
            var index = 0;
            foreach (Match match in AngleBrackets.Matches(entry))
            {
                var content = match.Groups[0].Value;
                matches.Add(content);
                entry = entry.Replace(content, "<" + index + ">");
                index++;
            }

            if ((flags & UwuifyFlag.Yu) == UwuifyFlag.Yu)
                entry = DoYu(entry);

            if ((flags & UwuifyFlag.Nouwu) != UwuifyFlag.Nouwu)
                entry = DoUwu(entry);

            if ((flags & UwuifyFlag.Stutter) == UwuifyFlag.Stutter)
                entry = DoStutter(entry);

            if ((flags & UwuifyFlag.Smiley) == UwuifyFlag.Smiley)
                entry = DoSmiley(entry);

            // Replace the content between angle brackets
            for (var i = 0; i < matches.Count; i++)
            {
                entry = entry.Replace("<" + i + ">", matches[i]);
            }

            return entry;
        }
    }
}