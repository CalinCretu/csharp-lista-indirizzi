namespace csharp_lista_indirizzi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\calin\source\repos\csharp-lista-indirizzi\addresses.csv"; // dichiaro una variabile per richiamare il percorso del file con gli indirizzi

            try
            {
                string[] lines = File.ReadAllLines(filePath);           // leggo tutte le righe del file

                List<Address> addressList = new List<Address>();        // creo lista per memorizzare gli oggetti Address

                for (int i = 1; i < lines.Length; i++) 
                {
                    string[] fields = lines[i].Split(',');

                    if (fields.Length >= 6)                             // verifico se ci sono almeno 6 campi
                    {                                                   // estraggo i valori dei campi
                        string name = fields[0];
                        string surname = fields[1];
                        string street = fields[2];
                        string city = fields[3];
                        string province = fields[4];
                        string zip = fields[5];

                        if (string.IsNullOrWhiteSpace(name))        // sostituisco il valore dei campi mancanti con valori predefiniti
                        {
                            name = "Nome non trovato";
                        }
                        if (string.IsNullOrWhiteSpace(surname))
                        {
                            surname = "Cognome non trovato";
                        }
                        if (string.IsNullOrWhiteSpace(street))
                        {
                            street = "Via non trovata";
                        }
                        if (string.IsNullOrWhiteSpace(city))
                        {
                            city = "Città non trovata";
                        }
                        if (string.IsNullOrWhiteSpace(province))
                        {
                            province = "Provincia non trovata";
                        }
                        if (string.IsNullOrWhiteSpace(zip))
                        {
                            zip = "CAP non trovato";
                        }

                        if (fields.Length > 6)          // controllo se ci sono valori aggiuntivi
                        {
                            Console.WriteLine($"Attenzione: Troppi valori nel campo ZIP nella riga {i}. Ho effettuato una concatenazione dei campi.\n");
                            
                            zip = string.Join(",", fields.Skip(5));         // dato che so quale e' il valore aggiuntivo lo concateno per avere il risultato desiderato
                        }

                        addressList.Add(new Address(name, surname, street, city, province, zip));           // aggiungo un nuovo oggetto Address alla lista
                    }
                    else
                    {
                        // gestisco il caso in cui ci sia un numero insufficiente di campi
                        Console.WriteLine($"Errore nella riga {i}: L'utente {fields[0]}, {fields[1]} non ha inserito correttamente i valori richiesti. Non è stato possibile salvare i dati nella libreria ＞__＜\n");
                    }
                }

                foreach (var address in addressList)            // STAMPO A SCHERMO LA LISTA DI INDIRIZZI
                {
                    Console.WriteLine(address);
                }

                try
                {           // salvo la lista di indirizzi in un nuovo file
                    string newFilePath = @"C:\Users\calin\source\repos\csharp-lista-indirizzi\new_address_file.csv"; // percorso del nuovo file

                    using (StreamWriter writer = new StreamWriter(newFilePath))             // crea file
                    {
                        writer.WriteLine("Name,Surname,Street,City,Province,ZIP");          // intestazione del file

                        foreach (var address in addressList)                                // ciclo la lista di indirizzi e li scrivo nel file
                        {
                            writer.WriteLine($"{address.Name},{address.Surname},{address.Street},{address.City},{address.Province},{address.ZIP}");
                        }
                    }

                    Console.WriteLine("\nLista di indirizzi salvata con successo in new_address_file.csv");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Errore durante il salvataggio del file: {ex.Message}");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File non trovato. Assicurati che il percorso sia corretto.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura del file: {ex.Message}");
            }
        }
    }
}