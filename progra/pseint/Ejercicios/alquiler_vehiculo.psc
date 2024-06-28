Algoritmo alquiler_vehiculo
	Definir recorrido, monto, monto_fijo, iva Como Real
	Escribir "Ingrese el recorrido (Km)"
	Leer recorrido
	
	monto_fijo = 300000
	
	Si recorrido <= 300 Entonces
		monto = monto_fijo
	SiNo
		Si recorrido <= 1000 Entonces
			monto = monto_fijo + ((recorrido-300) * 15000)
		SiNo
			monto = monto_fijo + ((recorrido-1000) * 10000)
		FinSi
	FinSi
	
	Escribir "El monto a pagar por el alquiler es de: ", monto
	
	iva = monto * 0.2
	Escribir "El monto incluido del impuesto de: ", iva
	
FinAlgoritmo
