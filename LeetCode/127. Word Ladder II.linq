<Query Kind="Program" />

void Main()
{
	
	Solution sol = new Solution();
	List<string> dictionary = new List<string>();
	
	string beginWord = "cet";
	string endWord = "ism";
	string[] words = {
"kid","tag","pup","ail","tun","woo","erg","luz","brr","gay","sip","kay","per","val","mes","ohs","now","boa","cet","pal","bar","die","war","hay","eco","pub","lob","rue","fry","lit","rex","jan","cot","bid","ali","pay","col","gum","ger","row","won","dan","rum","fad","tut","sag","yip","sui","ark","has","zip","fez","own","ump","dis","ads","max","jaw","out","btu","ana","gap","cry","led","abe","box","ore","pig","fie","toy","fat","cal","lie","noh","sew","ono","tam","flu","mgm","ply","awe","pry","tit","tie","yet","too","tax","jim","san","pan","map","ski","ova","wed","non","wac","nut","why","bye","lye","oct","old","fin","feb","chi","sap","owl","log","tod","dot","bow","fob","for","joe","ivy","fan","age","fax","hip","jib","mel","hus","sob","ifs","tab","ara","dab","jag","jar","arm","lot","tom","sax","tex","yum","pei","wen","wry","ire","irk","far","mew","wit","doe","gas","rte","ian","pot","ask","wag","hag","amy","nag","ron","soy","gin","don","tug","fay","vic","boo","nam","ave","buy","sop","but","orb","fen","paw","his","sub","bob","yea","oft","inn","rod","yam","pew","web","hod","hun","gyp","wei","wis","rob","gad","pie","mon","dog","bib","rub","ere","dig","era","cat","fox","bee","mod","day","apr","vie","nev","jam","pam","new","aye","ani","and","ibm","yap","can","pyx","tar","kin","fog","hum","pip","cup","dye","lyx","jog","nun","par","wan","fey","bus","oak","bad","ats","set","qom","vat","eat","pus","rev","axe","ion","six","ila","lao","mom","mas","pro","few","opt","poe","art","ash","oar","cap","lop","may","shy","rid","bat","sum","rim","fee","bmw","sky","maj","hue","thy","ava","rap","den","fla","auk","cox","ibo","hey","saw","vim","sec","ltd","you","its","tat","dew","eva","tog","ram","let","see","zit","maw","nix","ate","gig","rep","owe","ind","hog","eve","sam","zoo","any","dow","cod","bed","vet","ham","sis","hex","via","fir","nod","mao","aug","mum","hoe","bah","hal","keg","hew","zed","tow","gog","ass","dem","who","bet","gos","son","ear","spy","kit","boy","due","sen","oaf","mix","hep","fur","ada","bin","nil","mia","ewe","hit","fix","sad","rib","eye","hop","haw","wax","mid","tad","ken","wad","rye","pap","bog","gut","ito","woe","our","ado","sin","mad","ray","hon","roy","dip","hen","iva","lug","asp","hui","yak","bay","poi","yep","bun","try","lad","elm","nat","wyo","gym","dug","toe","dee","wig","sly","rip","geo","cog","pas","zen","odd","nan","lay","pod","fit","hem","joy","bum","rio","yon","dec","leg","put","sue","dim","pet","yaw","nub","bit","bur","sid","sun","oil","red","doc","moe","caw","eel","dix","cub","end","gem","off","yew","hug","pop","tub","sgt","lid","pun","ton","sol","din","yup","jab","pea","bug","gag","mil","jig","hub","low","did","tin","get","gte","sox","lei","mig","fig","lon","use","ban","flo","nov","jut","bag","mir","sty","lap","two","ins","con","ant","net","tux","ode","stu","mug","cad","nap","gun","fop","tot","sow","sal","sic","ted","wot","del","imp","cob","way","ann","tan","mci","job","wet","ism","err","him","all","pad","hah","hie","aim","ike","jed","ego","mac","baa","min","com","ill","was","cab","ago","ina","big","ilk","gal","tap","duh","ola","ran","lab","top","gob","hot","ora","tia","kip","han","met","hut","she","sac","fed","goo","tee","ell","not","act","gil","rut","ala","ape","rig","cid","god","duo","lin","aid","gel","awl","lag","elf","liz","ref","aha","fib","oho","tho","her","nor","ace","adz","fun","ned","coo","win","tao","coy","van","man","pit","guy","foe","hid","mai","sup","jay","hob","mow","jot","are","pol","arc","lax","aft","alb","len","air","pug","pox","vow","got","meg","zoe","amp","ale","bud","gee","pin","dun","pat","ten","mob"	
	
	};
	dictionary.AddRange(words);
	IList<IList<string>> r = sol.FindLadders(beginWord, endWord, dictionary);
	
	for (int i = 0; i < r.Count; i++)
	{
		IList<string> t = r.ElementAt(i);
		string temp = string.Join("-",t.ToArray());
		Console.WriteLine(temp);
		
	}
	
}

// Define other methods and classes here
// Define other methods and classes here
public class Solution
{
    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
    {
        List<IList<string>> result = new List<IList<string>>();

        int minDepth = 0;

        HashSet<string> dictionary = new HashSet<string>();
        wordList.ToList().ForEach(a => dictionary.Add(a));

        List<Word> beginSet = new List<Word>();
        List<Word> endSet = new List<Word>();
        beginSet.Add(new Word() { Str = beginWord });
        endSet.Add(new Word() { Str = endWord });

        bool toggle = true;

        while (true)
        {
            minDepth++;

            var checkQuery =
                from a in beginSet
                from b in endSet
                where a.Str == b.Str
                select new { seta = a, setb = b };

            // if found
            if (checkQuery.Any())
            {
                foreach (var found in checkQuery)
                {
                    string[] beginSetResult = GetWordHistory(found.seta);
                    string[] endSetResult = GetWordHistory(found.setb);
                    List<string> partFound = new List<string>();
                    partFound.AddRange(beginSetResult.Reverse());
                    endSetResult = endSetResult.Skip(1).ToArray();
                    partFound.AddRange(endSetResult);
                    result.Add(partFound);
                }
                if(result.Count > 0)
                    return result;
            }
			
			// since we are using, class not a string, List is better than HashSet for successive access
            List<Word> tempBeginSet = new List<Word>();
            List<Word> tempEndSet = new List<Word>();

            if (toggle)
            {
                // update begin Set
                for (int i = 0; i < beginSet.Count; i++)
                {
                    Word queryWord = beginSet.ElementAt(i);
                    string query = queryWord.Str;
                    List<Word> tempResult = GetAllThings(query, dictionary, beginWord);
                    tempResult.ForEach(a =>
                    {
                        a.Parent = queryWord;
                        tempBeginSet.Add(a);
                    });
                }
                beginSet = tempBeginSet;
                toggle = !toggle;
            }
            else
            {
                for (int i = 0; i < endSet.Count; i++)
                {
                    Word queryWord = endSet.ElementAt(i);
                    string query = queryWord.Str;
                    List<Word> tempResult = GetAllThings(query, dictionary, beginWord);
                    tempResult.ForEach(a => { 
                        a.Parent = queryWord;
                        tempEndSet.Add(a);
                    });
                }
                endSet = tempEndSet;
                toggle = !toggle;
            }

            // exit count
            if (minDepth > dictionary.Count)
                break;
        }

        return result;
    }

    public List<Word> GetAllThings(string str, HashSet<string> dictionary, string beginWord)
    {
        List<Word> result = new List<Word>();

        if (str != beginWord && !dictionary.Contains(str))
            return result;

        char[] arr = str.ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            char c = arr[i];
            for (int j = 'a'; j <= 'z'; j++)
            {
                if (c == ((char)j))
                    continue;

                string temp = str.Remove(i, 1).Insert(i, ((char)j) + "");

                if (dictionary.Contains(temp))
                {
                    Word w = new Word();
                    w.Str = temp;
                    result.Add(w);
                }
            }
        }
        return result;
    }

    public string[] GetWordHistory(Word w)
    {
        List<string> result = new List<string>();
        
        Word cursor = null;
        cursor = w;
        while(cursor != null)
        {
            result.Add(cursor.Str);
            cursor = cursor.Parent;
        }
        
        return result.ToArray();
    }

    public class Word
    {
        public Word Parent { get; set; }
        public string Str { get; set; }
    }
}