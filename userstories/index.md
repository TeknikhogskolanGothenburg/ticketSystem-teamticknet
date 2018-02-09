# User stories

Use this template when writing the user stories:

"As a < type of user >, I want < some goal > so that < some reason >."

Create a new Markdown file for each userstory and create a toc.yml in the userstories folder, and add each userstory to the TOC (table of content).

Read more on userstories at [https://www.mountaingoatsoftware.com/agile/user-stories
](https://www.mountaingoatsoftware.com/agile/user-stories)

There is in the system (at least) three kind of users:

* Ticket buyer, a person who wants to buy one or more tickets
* Administrator, a person who is able to manage the ticket system, like added new events and control the sale of the ticksts
* 3th party system, a system which uses the Web API to do operations in the system

# Our user stroy

* Som utvecklare vill vi skapa ett söksystem för att köpare ska kunna hitta event.
* Som köpare vill jag kunna söka på ett event för att köpa det.
* Som köpare vill jag kunna söka på eventets placering, eventets namn eller datum för att hitta det eventet som passar mig.
* Som administrator vill jag kunna lägga in nya event och radera gamla för att websidan ska vara aktuell för köpare.
* Som utvecklare vill vi kunna skapa funktioner som gör att admin kan lägga in nya och radera gamla event.
* Som utvecklare vill vi kunna skapa ett system som kan skilja mellan admin och köpare för att endast admin ska kunna 
	ändra i event utbudet.
* Som utvecklare vill vi skapa en login sida, som ser till att endast admin kan göra ändringar, för att systemet ska vara säkert.
* Som utvecklare vill vi skapa två stycken views, där den ena är för admin och andra för köpare, för att webplatsen ska vara
aktuell för den som besöker den.
* Som köpare vill jag kunna se priser på mina event för att veta om jag har råd att köpa det.
* Som köpare vill jag kunna se vilja event jag har köpt för att undvika dubbelbokningar.
* Som utvecklare vill vi att köparnas inköp ska kunna sparas för att de ska se vilka event de har köpt.
* Som utvecklare vill vi skapa login åt köpare för att kunna spara deras profil och inköp.
