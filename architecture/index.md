# Ticket system architecture

* How are your ticket system build?
* Which components does your application consist of?

# V�rt projekt

* I v�r RestApi sln har vi flera controllers som h�mtar, postar och deletar inneh�ll fr�n v�r databas.
* V�r sql databas �r uppladdat p� Azure cloud och p� det s�ttet har vi alla �tkomst till en och samma databas.
* Vi har ett project som heter RestApiClient som kommunicerar med RestApi.sln och dess controllers.
* Metoderna i RestApiClient ser till att komma till metoderna Get, post och delete i RestApi.sln.
* N�r programmet n�r Get, post och delete metoderna i RestApi.sln anropas funktionerna i TicketDatabase classen, 
som utf�r det �nskv�rda resultatet. 
* Ex vi/admin vill posta information om event i databasen. F�r att g�ra det startas en view i v�r Backoffice.sln som heter
events och som best�r av textboxar d�r admin skriver in info som admin vill posta. N�r admin trycket p� submit knappen g�r 
programmet till events funktionen i homecontrollern i Backoffice sln. I denna controller anropas TicketApi classen, som
finns i v�r RestApiClient proj. D�r finns funktionen som arbetar med att anropa post metoden f�r event i RestApi.sln.
Programmet g�r d� till EventsCotrollen i RestApi.sln och hittar Post metoden. I post metoden finns ett return som best�r
av en funktion som finns i TicketDatabase classen och som i sin tur l�gger till informationen om eventet i v�r databas.
* Vad g�ller Get metoden ville vi att usern skulle kunna s�ka info p� samma s�tt, via en textbox i viewn men �n s�
l�nge g�r det endast att s�ka direkt i url som startas ifr�n RestApi sln. 
* Vi ville g�ra en inlogg sida, som sparar uppgifter om v�ra user. Vi skapade tv� klasser i v�r ClassLibrary (vilket 
�r en proj som delas mellan Backoffice sln, Ticketshop sln och RestApi sln) UserReg och SiteUser. UserReg anv�nds f�r
att spara info om en ny user i v�r databas och SiteUser anv�nds f�r att en user ska kunna logga in p� ticketshop sidan.
* P� samma s�tt ville vi g�ra registration f�r Admin. P� s� s�tt hade man kommit till olika sidor, beroende p� om man
�r user eller admin. Det ville vi g�ra f�r att skilja admin och user �t, d� admin har befogenheter att �ndra, posta och deleta
informationen som finns i databasen, medan user endast har befogenhet att s�ka bland befintlig info (tex om events och venues)
samt k�pa biljett.
* Vi ville att user skulle kunna s�ka bland befintliga event och l�gga till eventet av intresse till en shoppingkorg
f�r att k�pet skulle genomf�ras. 
* Vi hade gjort det genom kopplingen mellan datumet f�r eventet och ticket tabellerna i databasen. 
* I TicketDatabase finns en funktion som h�mtar alla event f�r datum man s�ker p�. Vi ville att user skulle d� kunna v�lja
event f�r det datumet som passar och sedan klicka p� eventet, varefter programmet g�r till en controller som inneh�ller en funktion
som l�gger till det �nskade datumet till ticket och ticketSeat samt genomf�r en transaktion. Tillbaka f�r user en f�rdig biljett
som �ven inneh�ller information om user, som ju redan finns i databasen, eftersom usern m�ste registrera sig innan
den f�r s�ka events och genomf�ra k�p.  

# Context diagram

<img src="images/context.png" />

# Container diagram

<img src="images/container.png" />

# Database

<img src="images/database_diagram.png" />