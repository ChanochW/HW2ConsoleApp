namespace HW2ConsoleApp.PresidentialEligibility; 

public class ConsoleApp {
    private bool _naturalBorn, _treasonous;
    private int _birthYear, _lengthOfResidence, _numOfPrevTerms;
    
    public void LoadForm() {
        Console.WriteLine("US Presidential Eligibility Check: ");
        
        Ask("Are you a natural born US citizen? (yes/no) ", 1);
        Ask("What is your birth year? ('yyyy') ", 2);
        Ask("How many years have you resided in the USA? ", 3);
        Ask("How many prior terms have you served? ", 4);
        Ask("Have you rebelled against the US? (yes/no) ", 5);
    }

    public void Respond() {
        var potentialCandidate = new PotentialCandidate(
            _birthYear,
            _lengthOfResidence,
            _numOfPrevTerms,
            _naturalBorn,
            _treasonous
        );

        Console.WriteLine(potentialCandidate.DetermineEligibility()
            ? "Congratulations! You are an eligible candidate for the office of the president."
            : "We are sorry to inform you that you are ineligible for the presidential role.");
    }

    private void Ask(string message, int questionNum) {
        Console.Write(message);
        string? input = Console.ReadLine();

        while (string.IsNullOrEmpty(input)) {
            Console.Write("Please enter a an input, then press enter to continue. ");
            input = Console.ReadLine();
        }

        switch (questionNum) {
            case 1:
                while (input!.ToLower().Trim() != "yes" && input.ToLower().Trim() != "no") {
                    Console.Write("You must enter a \"yes\" or \"no\" value! ");
                    input = Console.ReadLine();
                }

                _naturalBorn = input switch {
                    "yes" => true,
                    _ => false
                };

                break;
            case 2:
                while (input!.ToLower().Length == 4 && !int.TryParse(input, out _)) {
                    Console.Write("You must enter a 4 digit year! ");
                    input = Console.ReadLine();
                }
                
                int.TryParse(input, out var num1);

                _birthYear = num1;

                break;
            case 3: 
                while (!int.TryParse(input, out _)) {
                    Console.Write("You must enter a number! ");
                    input = Console.ReadLine();
                }
                
                int.TryParse(input, out var num2);

                _lengthOfResidence = num2;

                break;
            case 4: 
                while (!int.TryParse(input, out _)) {
                    Console.Write("You must enter a number! ");
                    input = Console.ReadLine();
                }

                int.TryParse(input, out var num3);
                
                _numOfPrevTerms = num3;

                break;
            default: 
                while (input!.ToLower().Trim() != "yes" && input.ToLower().Trim() != "no") {
                    Console.Write("You must enter a \"yes\" or \"no\" value! ");
                    input = Console.ReadLine();
                }

                _treasonous = input switch {
                    "yes" => true,
                    _ => false
                };

                break;
        }
    }
}