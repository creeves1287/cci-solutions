using System.Collections.Generic;

namespace PermutationsWithoutDups
{
    public interface IPermutationGenerator
    {
        List<string> GeneratePermutations(string s);
    }
}