# code-patterns-backend

Instruktioner:

	Lägg till din connection string i appsettings.json "DatabaseSettings": "ConnectionString"

	Kör Package Manager Console
		-add-migration
		-update-database

	Starta upp projektet
		-Använd DefaultProductsController via swagger för att lägga till färdiga produkter i databasen


Om projektet:
	
	Jag har använt mig utav SOLID principerna och DRY när jag byggt det här backend projektet.
	Det har ibland varit svårt att kombinera DRY och SOLID och man måste då kompromissa
	och ta beslut om vad som faktiskt är viktigast.
	Jag har kommenterat varje separat klass kortfattat med vilka principer som använts.
	SRP följs i alla klasser medans tex LSP inte alls används lika mycket och det beror på att
	behovet för detta inte funnits överallt. 
