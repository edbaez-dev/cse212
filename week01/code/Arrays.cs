public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of doubles with size equal to 'length', since we need
        //    exactly that many multiples in the result.
        // 2. Loop from i = 0 to i = length - 1.
        // 3. On each iteration, calculate the (i + 1)-th multiple of 'number' by
        //    multiplying 'number' by (i + 1). This way, when i = 0 we get 1 * number,
        //    when i = 1 we get 2 * number, and so on.
        // 4. Store that value in the array at index i.
        // 5. After the loop finishes, return the completed array.

        var multiples = new double[length];
        for (var i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. The last 'amount' elements of the list need to move to the front,
        //    and the remaining elements (everything before them) need to follow
        //    right after, in their original order.
        // 2. Use GetRange to split the list into two pieces:
        //    - The tail: the last 'amount' elements, starting at index
        //      (data.Count - amount) and taking 'amount' elements.
        //    - The head: everything else, from index 0 up to (data.Count - amount).
        // 3. Clear the original list.
        // 4. Add the tail piece first, then the head piece, so the tail now
        //    appears at the front, followed by the rest of the original data.

        var tail = data.GetRange(data.Count - amount, amount);
        var head = data.GetRange(0, data.Count - amount);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
