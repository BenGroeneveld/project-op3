import java.awt.*;
import java.awt.print.*;
import java.util.*;
import javax.print.*;
import java.time.LocalDate;
import java.time.LocalTime;

public class PrintSettings implements Printable
{
	private int pages;
    private String cash;
    private PageFormat pagef = new PageFormat();
    private LocalDate getDate = LocalDate.now();
    private LocalTime getTime = LocalTime.now();
    private String datum = "Datum: "+getDate;
    private String tijd = "Tijd: "+getTime;

    public PrintSettings(String cash, int pages)
    {
    	this.cash = cash;
    	this.pages = pages;

    }

    //initializes an printable object and sends it to the given printer service.
    public void printCash(String printerName)
    {
        try
        {
        	PrintService ps = findPrintService(printerName);                                    
        	PrinterJob job = PrinterJob.getPrinterJob();            
        	job.setPrintService(ps);
            Paper p = new Paper();

            p.setSize(2.1*72.0 ,4.0*72.0);
            p.setImageableArea(0.0, 0.0, 2.0 * 72, 3.9* 72);


            pagef.setPaper(p); 
        	job.setPrintable(this, pagef);
            boolean ok = job.printDialog();
            job.print();
        }
        catch(PrinterException pe)
        {
        	System.out.println("Something went wrong...");
        }
    }

    //finds printer.....
    public PrintService findPrintService(String printerName)
    {
        for (PrintService service : PrinterJob.lookupPrintServices())
        {
            if (service.getName().equalsIgnoreCase(printerName))
                return service;
        }

        return null;
    }
	
	
    //edit page and/or text configurations here
	public int print(Graphics g, PageFormat pf, int page) throws PrinterException
    {
 
        if (page > (pages-1)) 
        {
            return NO_SUCH_PAGE;
        }
        //pf.setOrientation(PageFormat.LANDSCAPE);

        Graphics2D g2d = (Graphics2D)g;
        g2d.translate(pf.getImageableX(), pf.getImageableY());
 
        int x = (int)(pf.getImageableWidth() /6);
        int y = (int)(pf.getImageableHeight() /20 * 17);
        g.setFont(new Font("Arial Black", Font.PLAIN, 50));
        g.drawString(this.cash, x, y);
        /////-----------------------------------------------
        g.setFont(new Font("Geneva", Font.PLAIN, 14));
        x = (int)(pf.getImageableWidth() /10 * 4);
        y = (int)(pf.getImageableHeight()/10);
        g.drawString("SOFA", x, y);
        x = 0;
        y = (int)(pf.getImageableHeight()/20 * 3);
        g.drawString("----------------------------", x, y);
        /////-----------------------------------------------
        g.setFont(new Font("Geneva", Font.PLAIN, 9));
        x = (int)(pf.getImageableWidth() /10);
        y = (int)(pf.getImageableHeight()/20 * 6);
        g.drawString(tijd, x, y);
        ////------------------------------------------------
        x = (int)(pf.getImageableWidth() /10);
        y = (int)(pf.getImageableHeight()/20 * 7);
        g.drawString(datum, x, y);

        return PAGE_EXISTS;
    }
}