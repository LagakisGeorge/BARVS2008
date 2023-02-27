 δουλευει και με mdb και με SQLSERVER
 
 STO CONFIG.INI
 

AN UELV SQL SERVER ΒΑΖΩ 1Η ΣΕΙΡΑ :
Server=lagdell\sqlexpress;Database=BAR;UID=sa;pwd=12345678;
Server=lagdell\sqlexpress,52735;Database=BAR;UID=sa;pwd=12345678;


ΑΝ ΘΕΛΩ ACCESS BAZΩ 1Η ΣΕΙΡΑ :
Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\databaseBAR.MDB;


TOTE PREPEI NA EXO STO TREXON DIRECTORY TO databaseBAR.MDB    
ΝΑ ΔΗΛΩΝΕΤΑΙ ΜΕ ΚΕΦΑΛΑΙΑ ΣΤΟ CONFIG.INI


2h seira =user



//////////////////////////////////////////////////////////////////////////////////////////////
 
 Using sr As StreamReader = New StreamReader("config.ini", System.Text.Encoding.Default)
          
            m_mess_pel = sr.ReadLine()
            m_user = sr.ReadLine()
            gPass = sr.ReadLine()
            

        End Using


        'ConString = "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
        gCONNECT = m_mess_pel   ' "Server=" + Split(line, ";")(0) + ";Database=" + Split(line, ";")(1) + ";uid=" + Split(line, ";")(2) + ";pwd=" + Split(line, ";")(3) + ";"
        gUser = Val(m_user)


        Me.Text = "Σερβιτόρος : " + m_user
















HAMACHI OKO CLEAN
OKOCLEAN
OKOCLEAN48229



ALTER SE IDENTITY INTEGER

Alter Table XAR2
Add Id_new Int Identity(1, 1)
Go

Alter Table XAR2 Drop Column ID
Go

Exec sp_rename 'XAR2.Id_new', 'ID', 'Column'