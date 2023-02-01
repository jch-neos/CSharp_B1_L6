using System;
using System.Data.SqlClient;
using System.Net;
using System.Web;

class Pr{
    static void Main(){
        new Cl().A();
    }
}

class Cl {
    

    public void A(){
    
        try {
            B();
        } catch (Exception e){
            Console.WriteLine(e.Source);
            Console.WriteLine(e.TargetSite);
            Console.WriteLine(e.StackTrace); 
        }
        
        Console.WriteLine(new Exception().TargetSite);

    }

        void B(){
    
        try {
            C();
        } catch (Exception e){
            Console.WriteLine(e.Source);
            Console.WriteLine(e.TargetSite);
            Console.WriteLine(e.StackTrace);
            throw e;
        }
    
    }
    void C(){
    
        try {
            D();
        } catch (Exception e){
            Console.WriteLine(e.Source);
            Console.WriteLine(e.TargetSite);
            Console.WriteLine(e.StackTrace);
            throw;
        }
    
    }
    void D() => throw new Exception();

}