# LogApplication

## Principios SOLID

 1. S: Se ajusta la implementación de la clase de manera que se separa en clases independientes la escritura en cada uno de los mecanismos de log.
 2. L: Se crea una interfaz para identificar con claridad las funcionalidades expuesta por estas clases.
 3. I: Se definen claramente en la interfaz de los log y de el el enrutador de los mensajes a cada una de los logger específicos.
 4. D: Se aplica este principio con la aplicación, al momento de la implementación de las clases de Loggeo y la interfaz que se encargará del control de los mensajes con base en la configuración.

## Patrones

 - Factory Metod: se realiza la implementación de este patrón para el instanciamiento de las clases concretas de log, de esta manera se permite la creación de estos objetos de manera centralizada reduciendo el acoplamiento y de igual manera permite la creación de multiples instancias de las clases concretas en caso de ser requerido.
 - Dependecy injection: Se aplica este patrón en la fachada que se encarga del ruteo a cada una de las clases concretas, que es inyectada con un scope singleton de manera que se mantenga una única instancia de esta clase que contiene la configuración de las clases concretas y los mensajes que deben ser registrados.
## Diseño
Se realiza una Aplicación Rest, que tiene un método POST el cual recibe el mensaje a ser procesado y realiza el llamado a la fachada del servicio que realiza el control del envío de los mensajes a su respectiva clase concreta.
Se crea una capa que se encarga de cargar la configuración que se encuentra en web.config, de las clases concretas que deben ser instanciadas y los mensajes que deben ser registrados. Con base en estas configuraciones se realiza la construcción de las clases concretas a través de una fábrica de manera que puedan ser construidos los que sean requeridos.
Finalmente se crea una interfaz para el control de las clases que realizan la escritura en los diferentes medios, y se rediseña la forma en la que se realizaba la implementación de cada uno de los procesos de escritura de los medios.
