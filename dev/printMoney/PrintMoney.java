public class PrintMoney
{
	private static String printValue;
	private static int pages;

	public PrintMoney(int cash, int amount)
	{
		
		//-----------------------------SETUP------------------------//

		// available cash values:
		// 1 = 5 euro
		// 2 = 10 euro
		// 3 = 20 euro
		// 4 = 50 euro

		setPrintValue(cash); //set cash value

		setPages(amount); //set amount of pages
		
		//----------------------------------------------------------//

		PrintSettings pwd = new PrintSettings(printValue, pages);
		//pwd.printCash("HP Deskjet F300 series");
		pwd.printCash("DYMO LabelWriter 400");
	}

	public static void setPrintValue(int choice)
	{
		switch(choice)
		{
			case 1: printValue = "€5"; break;
			case 2: printValue = "€10"; break;
			case 3: printValue = "€20"; break;
			case 4: printValue = "€50"; break;
		}
	}

	public static void setPages(int p)
	{
		pages = p;
	}

}