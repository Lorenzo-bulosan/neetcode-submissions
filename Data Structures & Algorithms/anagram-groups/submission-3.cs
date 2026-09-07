public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) {
        
        var anagramGroups = new Dictionary<string, List<string>>();
        var encodedWord = string.Empty;
        foreach(var word in strs){
            encodedWord = EncodeWord(word);
            
            //anagramGroups[encodedWord] = anagramGroups.GetValueOrDefault(encodedWord, new List<string>()).Add(word);
            
            if(!anagramGroups.ContainsKey(encodedWord)){
                anagramGroups[encodedWord] = new List<string>();
            }

            anagramGroups[encodedWord].Add(word);
        }

        var result = new List<List<string>>();
        foreach(var kvp in anagramGroups){
            result.Add(kvp.Value);
        }

        return result;
    }

    public string EncodeWord(string word){

        // Counting characters by using character as position wrt 'a'
        var bucketList = new int[26];
        foreach(var ch in word){
            // Console.WriteLine($"{kvp.Key}:{kvp.Value}");
            bucketList[ch-'a'] += 1 ;
        }

        var result = string.Join(",", bucketList);

        // Console.WriteLine($"{word} is {result}");
        return result;
    }
}
