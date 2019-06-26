using System.Collections.Generic;

namespace PermutationsWithDups
{
    public interface IPermutationsGenerator
    {
        List<string> GeneratePermutations(string s);
    }
}