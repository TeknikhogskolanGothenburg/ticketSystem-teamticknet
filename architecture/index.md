# Ticket system architecture

* How are your ticket system build?
* Which components does your application consist of?

# Vårt projekt

* I vår RestApi sln har vi flera controllers som hämtar, postar och deletar innehåll från vår databas.
* Vår sql databas är uppladdat på Azure cloud och på det sättet har vi alla åtkomst till en och samma databas.
* Vi har ett project som heter RestApiClient som kommunicerar med RestApi.sln och dess controllers.
* Metoderna i RestApiClient ser till att komma till metoderna Get, post och delete i RestApi.sln.
* När programmet når Get, post och delete metoderna i RestApi.sln anropas funktionerna i TicketDatabase classen, 
som utför det önskvärda resultatet. 
* Ex vi/admin vill posta information om event i databasen. För att göra det startas en view i vår Backoffice.sln som heter
events och som består av textboxar där admin skriver in info som admin vill posta. När admin trycket på submit knappen går 
programmet till events funktionen i homecontrollern i Backoffice sln. I denna controller anropas TicketApi classen, som
finns i vår RestApiClient proj. Där finns funktionen som arbetar med att anropa post metoden för event i RestApi.sln.
Programmet går då till EventsCotrollen i RestApi.sln och hittar Post metoden. I post metoden finns ett return som består
av en funktion som finns i TicketDatabase classen och som i sin tur lägger till informationen om eventet i vår databas.
* Vad gäller Get metoden ville vi att usern skulle kunna söka info på samma sätt, via en textbox i viewn men än så
länge går det endast att söka direkt i url som startas ifrån RestApi sln. 
* Vi ville göra en inlogg sida, som sparar uppgifter om våra user. Vi skapade två klasser i vår ClassLibrary (vilket 
är en proj som delas mellan Backoffice sln, Ticketshop sln och RestApi sln) UserReg och SiteUser. UserReg används för
att spara info om en ny user i vår databas och SiteUser används för att en user ska kunna logga in på ticketshop sidan.
* På samma sätt ville vi göra registration för Admin. På så sätt hade man kommit till olika sidor, beroende på om man
är user eller admin. Det ville vi göra för att skilja admin och user åt, då admin har befogenheter att ändra, posta och deleta
informationen som finns i databasen, medan user endast har befogenhet att söka bland befintlig info (tex om events och venues)
samt köpa biljett.
* Vi ville att user skulle kunna söka bland befintliga event och lägga till eventet av intresse till en shoppingkorg
för att köpet skulle genomföras. 
* Vi hade gjort det genom kopplingen mellan datumet för eventet och ticket tabellerna i databasen. 
* I TicketDatabase finns en funktion som hämtar alla event för datum man söker på. Vi ville att user skulle då kunna välja
event för det datumet som passar och sedan klicka på eventet, varefter programmet går till en controller som innehåller en funktion
som lägger till det önskade datumet till ticket och ticketSeat samt genomför en transaktion. Tillbaka får user en färdig biljett
som även innehåller information om user, som ju redan finns i databasen, eftersom usern måste registrera sig innan
den får söka events och genomföra köp.  

# Context diagram

<img src="images/context.png" />

# Container diagram

<img src="images/container.png" />

# Database

<img src="images/database_diagram.png" />