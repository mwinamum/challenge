public class Program
{
    public static string MathChallenge(string str)
    {
        int len = str.Length;
        if (len <= 1) return "-1";

        for (int lenK = len / 2; lenK >= 1; lenK--)
        {
            if (len % lenK == 0)
            {
                int n = len / lenK;
                string K = str.Substring(0, lenK);
                bool matches = true;
                for (int i = 1; i < n; i++)
                {
                    if (!str.Substring(i * lenK, lenK).Equals(K))
                    {
                        matches = false;
                        break;
                    }
                }
                if (matches)
                {
                    return K;
                }
            }
        }
        return "-1";
    }

    public static string ArrayChallenge(string str)
    {
        string[] parts = str.Split(',');
        if (parts.Length < 2) return "";

        int N = int.Parse(parts[0].Trim());
        List<int> numbers = new List<int>();
        for (int i = 1; i < parts.Length; i++)
        {
            numbers.Add(int.Parse(parts[i].Trim()));
        }

        int numCount = numbers.Count;
        string[] medians = new string[numCount];
        List<int> window = new List<int>();

        for (int i = 0; i < numCount; i++)
        {
            window.Add(numbers[i]);
            if (window.Count > N)
            {
                window.RemoveAt(0);
            }

            List<int> sorted = new List<int>(window);
            sorted.Sort();
            int count = sorted.Count;
            int mid = count / 2;
            int median;
            if (count % 2 == 1)
            {
                median = sorted[mid];
            }
            else
            {
                median = (sorted[mid - 1] + sorted[mid]) / 2;
            }
            medians[i] = median.ToString();
        }

        return string.Join(",", medians);
    }

    // Test examples
    public static void Main()
    {
        // MathChallenge tests
        Console.WriteLine(MathChallenge("abcxabc"));  // -1
        Console.WriteLine(MathChallenge("abcabc"));   // abc
        Console.WriteLine(MathChallenge("aaaa"));     // aa
        Console.WriteLine(MathChallenge("abc"));      // -1

        // ArrayChallenge tests
        Console.WriteLine(ArrayChallenge("3,1,3,5,10,6,4,3,1"));  // 1,2,3,5,6,6,4,3
        Console.WriteLine(ArrayChallenge("5,2,4,6"));             // 2,3,4
        Console.WriteLine(ArrayChallenge("3,0,0,-2,0,2,0,-2"));   // 0,0,0,0,0,0,0
    }
}