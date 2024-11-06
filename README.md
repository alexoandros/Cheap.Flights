# **Cheap flights**

Trabajas para una empresa que se dedica a la venta de paquetes turísticos, entre los que destacan las reserva de hoteles, coches...
Tu jefe acaba de firmar un acuerdo con varias aerolineas para poder realizar reservas a través de vuestra empresa.

Para esta tarea, necesitarás desarrollar una API que tenga la siguiente funcionalidad:

- Devolver listado de vuelos y precios para el día seleccionado, el número de pasajeros y el origen-destino.
- Poder realizar una reserva de un vuelo seleccionado del listado anterior.
- Poder recuperar información sobre una reserva realizada.

El formato puede estar en XML o JSON.

## **Recursos**

* Obtener la información de los vuelos de la API: https://otd-exams-data.vueling.app/cheap-flights/flight-rs-2.json

* La definición de los schemas para poder generar los modelos se obtienen de:
- FlightRq: https://otd-exams-data.vueling.app/cheap-flights/SchemaFlightRq-2.json
- FlighRs: https://otd-exams-data.vueling.app/cheap-flights/SchemaFlightRs-2.json
- BookingRq: https://otd-exams-data.vueling.app/cheap-flights/SchemaBookingRq-2.json
- BookingRs: https://otd-exams-data.vueling.app/cheap-flights/SchemaBookingRs-2.json
- RetrieveBookingRq: https://otd-exams-data.vueling.app/cheap-flights/SchemaRetrieveBookingRq.json
- Contact: https://otd-exams-data.vueling.app/cheap-flights/SchemaContact.json
- PaxType: https://otd-exams-data.vueling.app/cheap-flights/SchemaPaxType-2.json
- PaxPrice: https://otd-exams-data.vueling.app/cheap-flights/SchemaPaxPrice-2.json

* Recordar que los modelos son un ejemplo, y se pueden adaptar a las necesidades

## **TIPs** 
Hay que escoger el vuelo más barato del listado.
El precio de los vuelos está expresado en decimales (redondeado a 2)
El precio de la reserva varía en función del tipo de pasajero.
El número de la reserva es un identificador único (de 6 caracteres alfanuméricos) y no podrá repetirse.
Se debe comprobar que la información enviada es válida.
Los únicos modelos predefinidos son los de FlightRq, FlightRs, el resto los puedes adaptar según tus necesidades
No permitir reservas para vuelos ya volados.
	
## **cómo pistas te decimos lo que nos gustaría llegar a encontrar**
* Ver cómo cargas el listado de vuelos para una fecha.
* Ver cómo persistes la información de las reservas para poder recueparlas más adelante.
	* En el ejemplo se usa MemoryCache, pero se puede usar cualquier sistema
* Ver cómo separas por N capas el proyecto (Servicios distribuidos, capa de aplicación, capa de dominio, ...). 
* Ver cómo usas SOLID (separación de responsabilidades, Inversión de Dependencias, ...).
* Ver si usas un correcto naming-convention y consistente.
* Ver cómo cubres el código con pruebas unitarias
* Ver cómo defines y gestionas los mensajes (tanto de error como informativos) 
* Ver cómo usas el patrón async/await
* Ver cómo validas los modelos según las reglas de negocio definidas

## **Validaciones**
Tipos de pasajero aceptados:
- ADT (Adulto) (A partir de 16 años)
- CHD (Niño) 
BookingId: Longitud 6
Fecha de vuelo: Obligatoria
Origen: Obligatorio
Destino: Opcional
En la reserva debe haber mínimo 1 adulto.

## **Se valorará**
* Crear APIs por funcionalidad

  **Por favor, una vez finalizada la prueba simplemente debemos crear una petición de incorporación (Pull Request) hacía la rama de master del repositorio, y el último commit contenga en al descripción "Finished". Con esto podemos saber que la prueba ha sido finalizada.**
 