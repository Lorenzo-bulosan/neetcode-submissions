public class Solution {

    private char _delimiter {get; set;} = '-';

    /*
    ["hello", "world" ,"Doe"]
    => "5-hello4-world3-doe"
    */
    public string Encode(IList<string> strs) {
        var encoded = new StringBuilder();

        var currentWordCount = 0;
        foreach(var word in strs){
            
            currentWordCount = word.Count();

            encoded.Append(currentWordCount);
            encoded.Append(_delimiter);
            encoded.Append(word);
        }

        // Console.WriteLine(encoded.ToString());

        return encoded.ToString();
    }

    public List<string> Decode(string s) {

        var result = new List<string>();

        int i=0; 
        int endOfWord = 0;
        string currentWord = string.Empty;
        int wordLength = 0;
        int startOfNumber = 0;
        while(i < s.Count()){

            // get length of word
            // you cant just int.TryParse(s[i+1].ToString(), out int wordLength);
            // because what if the next word is 10 or 11 length? you would do 1, 0 separate chars
            // instead its a number until you hit the delimiter
            startOfNumber = i;
            while(i < s.Count() && s[i] != _delimiter){
                i++;
            }

            // get number and cast to int e.g "100" => 100 int
            int.TryParse(s[startOfNumber..i], out wordLength);

            // skip delimiter
            i++;

            // find end of substring - i is the end of the number portion but also the start of the word
            endOfWord = i+wordLength;

            // get substring
            currentWord = s.Substring(i, wordLength); //  s[i..endOfWord]; //

            // append to results list
            result.Add(currentWord);
            // Console.WriteLine(currentWord);

            // Move i to start of next word
            i = endOfWord;
        }

        return result;
   }
}
