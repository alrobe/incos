Algoritmo el_gloton
	Definir diametro_pizza Como Real
	Definir cantidad_ingredientes Como Entero
	Definir nombre Como Caracter
	
	Definir area_pizza, costo_basico, costo_ingredientes, costo_total, precio_venta Como Real
	Escribir "========= PIZZERIA EL GLOTON ========="
	Escribir "Por favor siga las instrucciones para realizar su pedido"
	Escribir ""
	Escribir "Ingrese su nombre"
	Leer nombre
	Escribir ""
	Escribir "Bienvenido ", nombre
	Escribir ""
	Escribir "Ingrese el diametro de la pizza (cm)"
	Leer diametro_pizza
	Escribir ""
	Escribir "Ingrese la cantidad de ingredientes"
	Leer cantidad_ingredientes
	Escribir ""
	area_pizza = (PI * (diametro_pizza * diametro_pizza))/4
	costo_basico = 0.16 * area_pizza
	costo_ingredientes = (cantidad_ingredientes * 0.003) * area_pizza
	costo_total = costo_basico + costo_ingredientes
	precio_venta = costo_total + (costo_total * 1.5)
	Escribir "El costo de su pedido es: ", precio_venta
FinAlgoritmo
