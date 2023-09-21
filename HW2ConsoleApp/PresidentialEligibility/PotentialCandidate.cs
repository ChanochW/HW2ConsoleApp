namespace HW2ConsoleApp.PresidentialEligibility; 

public class PotentialCandidate {
    private readonly int _birthYear, _lengthOfUsaResidence, _priorTerms;
    private readonly bool _naturalBorn, _treasonous;

    public PotentialCandidate(int birthYear, int lengthOfUsaResidence, int priorTerms, bool naturalBorn, bool treasonous) {
        _birthYear = birthYear;
        _lengthOfUsaResidence = lengthOfUsaResidence;
        _priorTerms = priorTerms;
        _naturalBorn = naturalBorn;
        _treasonous = treasonous;
    }

    public bool DetermineEligibility() {
        var year = DateTime.Now.Year;

        return _birthYear <= year - 35 &&
               _lengthOfUsaResidence >= 14 &&
               _priorTerms < 2 &&
               _naturalBorn &&
               !_treasonous;
    }
}