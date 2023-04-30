namespace DataStructuresAndAlgorithms.Arrays;

public abstract class MaxSubArraySum
{
    public static int Sum(int[] nums)
    {
        var maxSoFar = nums[0];
        var currMax = nums[0];

        foreach (var num in nums.Skip(1))
        {
            currMax = Math.Max(num, num + currMax);
            maxSoFar = Math.Max(maxSoFar, currMax);
        }

        return maxSoFar;
    }
}