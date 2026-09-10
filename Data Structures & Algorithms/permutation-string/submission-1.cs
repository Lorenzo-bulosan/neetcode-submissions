public class Solution {

    public bool CheckInclusion(string s1, string s2) {

        var s1Set = new Dictionary<char, int>();

        // count chars s1
        foreach(char c in s1)
            s1Set[c] = s1Set.GetValueOrDefault(c, 0) + 1;

        int l = 0;
        int r = l + s1.Length;

        while (l < r && r <= s2.Length)
        {
            // slice substring
            var currentSubstring = s2[l..r];

            // count chars of substring
            var subSet = new Dictionary<char, int>();
            foreach (char c in currentSubstring)
                subSet[c] = subSet.GetValueOrDefault(c, 0) + 1;

            // compare dictionaries
            bool match = true;

            // check all keys in s1Set
            foreach (var kvp in s1Set)
            {
                if (!subSet.ContainsKey(kvp.Key) || subSet[kvp.Key] != kvp.Value)
                {
                    match = false;
                    break;
                }
            }

            // check extra keys in subSet
            foreach (var kvp in subSet)
            {
                if (!s1Set.ContainsKey(kvp.Key))
                {
                    match = false;
                    break;
                }
            }

            if (match)
                return true;

            // slide window
            l++;
            r = l + s1.Length;
        }

        return false;
    }
}
