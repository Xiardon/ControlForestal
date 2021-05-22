# ControlForestal
Es una aplicación de consola que simula de manera básica el control y programación de drones para vigilar un área definida sobre un parque forestal.

## Modo de uso
Todas las ordenes se enviaran en líneas seguidas. Cada linea servirá para definir la acción. Usar espacios para separar los datos y pulsar intro
 para saltar a la siguiente
 linea.

1-En la primera linea se especifica la longitud X e Y (anchura y altura) del área que los drones patrullaran Ej: 5 5.

2-En la segunda linea se especifican las coordenadas X e y así como la orientación inicial del dron. Para la orientación usaremos los puntos cardinales: N,S
,E,O
. Ej: 3 3. E

3-En la tercera linea enviaremos las ordenes de vuelo del dron. Para ello usaremos 3 ordenes básicas: 'M' para avanzar, 'L' para girar a la izquierda 90º la orientación del dron y 'R' para girar a la derecha 90º. Ej: MRRLM


Podemos crear tantos drones y programarles su ruta tantas veces como queramos siguiendo los pasos 2 y 3 sucesivamente.
Una vez que ya no queramos añadir más drones a control de vuelo solo tenemos que pulsar intro
 sin introducir ningún dato y los drones comenzarán a ejecutar las ordenes que les hemos enviado.
Cada dron al finalizar la ejecución devolverá por consola la posición en la que se encuentra.

Ejemplo:

Enviamos las siguientes instrucciones:
5 5
3 3 E
MMRMMRMRRM


El dron devolveria
:
5 1 E

Si introdujéramos algún dato incorrecto el programa nos lo haría saber.
Si un dron no puede ejecutar una orden salta a la siguiente
.Ejemplo: Si el área es 5 5 y el dron tiene la posición 3 5 N al recibir la orden 'M' no se movería ya que se saldría del área definida.

# Autor
Marcos Álvarez Varela

# Licencia
GNU
