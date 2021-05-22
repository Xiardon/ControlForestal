# ControlForestal
Es una aplicacion de consola que simula de manera basica el control y programacion de drones para vigilar un area definida sobre un parque forestal.

## Modo de uso
Todas las ordenes se enviaran en lineas segidas. Cada linea servira para definir la accion. Usar espacios para separar los datos y pulsar intro para saltar a la siguiente linea.

1-En la primera linea se especifica la longitud X e Y (anchura y altura) del area que los drones patrullaran Ej: 5 5.

2-En la segunda linea se especifican las coordenadas X e y asi como la orientacion inicial del dron. Para la orientacion usaremos los puntos cardinales: N,S,E,O. Ej: 3 3. E

3-En la tercera linea enviaremos las ordenes de vuelo del dron. Para ello usaremos 3 ordenes basicas: 'M' para avanzar, 'L' para girar a la izquierda 90º la orientacion del dron y 'R' para girar a la derecha 90º. Ej: MRRLM

Podemos crear tantos drones y programarles su ruta tantas veces como queramos siguiendo los pasos 2 y 3 sucesivamente.
Una vez que ya no queramos añadir mas drones a control de vuelo solo tenemos que pulsar intro sin introducir ningun dato y los drones comezaran a ejecutar las ordenes que les hemos enviado.
Cada dron al finalizar la ejcucion devolvera por cosola la posicion en la que se encuentra.

Ejemplo:

Enviamos las siguientes instrucciones:
5 5
3 3 E
MMRMMRMRRM

El dron devolveria:
5 1 E

Si introducieramos algun dato incorrecto el programa nos lo haria saber.
Si un dron no puede ejecutar una orden salta a la siguiente.Ejemplo: Si el area es 5 5 y el dron tiene la posicion 3 5 N al recibir la orden 'M' no se moveria ya que se saldria del area definida.

# Autor
Marcos Álvarez Varela

# Licencia
GNU
