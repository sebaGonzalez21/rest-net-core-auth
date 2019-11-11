## Microservicio SGS
#### Nutget dependencias
+ Install-Package Swashbuckle.AspNetCore
+ Install-Package RestSharp -Version 106.5.4
+ Install-Package log4net -Version 2.0.8
### Ejecutar en Consola de Windows como administrador
+ netsh http add urlacl url=http://192.168.0.51:44369/ user=Interactive listen=yes 
+ netsh http add urlacl url=http://169.254.99.251:44369/ user=Interactive listen=yes
+ netsh http add urlacl url=http://10.175.2.158:9898/ user=todos