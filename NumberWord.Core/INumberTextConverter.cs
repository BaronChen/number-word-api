namespace NumberWord.Core
{
    public interface INumberTextConverter
    {
		string IntegerToWritten(string n, bool isUS = false);
	    string WrittenToInteger(string numberText);
    }
}
