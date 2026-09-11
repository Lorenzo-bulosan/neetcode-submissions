public class Solution {

    /*
    [1,4,3,2] = 10
    h = 9

    with k=1 => 1b/h * 9h = 9bananas
    can't we just (total_bannanas)/h = 10/9 = 1 + 1/9 => Math.Ceiling? to 2?

    e.g 2
    piles = [25,10,23,4], h = 4
    k = Math.Ceiling(62/4) => 62/4 = 15.5 => k=16 - does not work because 10 bananas at 16b/h you finish but cant start on next

    Instead lets try the max of array 25 - then i can do it in 4h

    But now im thinking what if h=2? No is not possible
        - so h is always at least same or more than piles length
    
    Okay so yes the maxOf(array) = is a valid solution - but not the minimum

    Could consider each item of array but what if answer is in between?

    So the answer is between 1-maxOf(array) in steps of 1.

    iterate until b/h * h >= sumBananas

    [1,2,3,...,25] => 1*4, etc >= 62?

    e.g 3
    [1,4,3,2]
    h = 9

    [1,4,3,2], 4 is max, and I would eat it in 4h - fastest
    minimum is then between 1-4

    [1,2,3,4] => 1*9=9h, 2*9=18h, 3*9=27h, 4*9=36h
    Choose between them, is 10h max, takes 9h for k=1, and 18h for k=2
    so all the k from 2-4 are valid but min is 2, and max is 4

    O(n) where n is the range of max num

    -----------------

    Actually this is not complete because the above means that koko eats from any pile
    with my chosen k, how many hours would it take?

    k = b/h but you don't finish it all so maybe a pile takes twice or three times

    so its actually the pile/k - rounded up, thats how many hours takes for that file
    so all of the pile would be sum(pile_i/k) where i is 0-end of array
    
    Its not enough to just say i*h >= sumBananas
    but sum(pile_i/k) = would give its hours, and then compare with the allowed hours

    the largest rate k still the largest pile as that ensures 1 pile per hour, and h is always valid for that

    So now algo is:
    - find largest pile
    - enumerate to test each speed from 1-largest pile
    - test for how many hours the total piles would take all together is it more than allowed
    */
    public int MinEatingSpeed(int[] piles, int h) {
        
        // find largest pile
        int largestPile = int.MinValue;
        foreach(var i in piles){
            largestPile = Math.Max(largestPile, i);
        }

        // binary search a number that satisfies a condition
        // no need for real array
        int l = 1;
        int r = largestPile;
        int k;
        while(l<=r){

            k = l+(r-l)/2;

            if (HoursToEatWithThisK(k, piles) <= h){
                r = k-1;
            }
            else{
                l = k+1;
            }
        }

        return l;
    }

    public int HoursToEatWithThisK(int k, int[] piles){

        // find how many hours it takes with this k
        int totalHours = 0;
        int hoursPerTile = 1;
        foreach(int pile in piles){
            hoursPerTile = (int)Math.Ceiling((double)pile/k); // int division in C# is towards 0
            totalHours += hoursPerTile;
        }
        return totalHours;
    }
}

