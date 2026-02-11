Algoritmo es_triangulo
	Definir longitud1, longitud2, longitud3 Como Real
	Definir estriangulo Como Logico
	Escribir "Ingrese la primera longitud"
	Leer longitud1
	Escribir "Ingrese la segunda longitud"
	Leer longitud2
	Escribir "Ingrese la tercera longitud"
	Leer longitud3
	
	SI longitud1 = longitud2 Y longitud2 = longitud3 Entonces
		Escribir "El triangulo es equilatero"
	SiNo
		estriangulo = Falso
		SI longitud1 > longitud2 Y longitud1>longitud3 Entonces
			estriangulo = longitud1 < (longitud2 + longitud3)
		SiNo
			Si longitud2 > longitud1 Y longitud2 > longitud3 Entonces
				estriangulo = longitud2 < (longitud1 + longitud3)
			SiNo
				Si longitud3 > longitud1 Y longitud3 > longitud2 Entonces
					estriangulo = longitud3 < (longitud1 + longitud2)
				FinSi
			FinSi
		FinSi
		
		Si estriangulo Entonces
			SI longitud1=longitud2 O longitud1=longitud3 O longitud2=longitud3 Entonces
				Escribir "El triangulo es isosceles"
			SiNo
				Si longitud1 <> longitud2 Y longitud2<>longitud3 Entonces
					Escribir "El triangulo es escaleno"
				FinSi
			FinSi
		SiNo
			Escribir "No es triangulo"
		FinSi
		
	FinSi
	
FinAlgoritmo
