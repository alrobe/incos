#!/bin/bash
# ESTRUCTURA EXAMEN TERCER BIMESTRE
# 1) Descarga este script 
# "wget https://raw.githubusercontent.com/alrobe/incos/main/tso/practica.sh"
# 2) Dale permisos de ejecucion
# "chmod +x practica.sh"
# 3) Ahora ejecuta el script cada que quieras tener la estructura desde cero 
# "./practica.sh"
rm -r Incos/
mkdir -p Incos/Administrativos/Poa
mkdir -p Incos/Administrativos/Finanzas
mkdir -p Incos/Docentes/Notas
mkdir -p Incos/Docentes/Materias
mkdir -p Incos/Docentes/MaterialEducativo
mkdir -p Incos/Estudiantes/Archivos/Instaladores/Configuracion
touch Incos/Estudiantes/Archivos/Instaladores/Configuracion/Configuracion1.txt
touch Incos/Estudiantes/Archivos/Instaladores/Configuracion/Configuracion2.txt
touch Incos/Estudiantes/Archivos/Instaladores/Configuracion/Configuracion3.txt
mkdir -p Incos/Estudiantes/Archivos/Material_Educativo
touch Incos/Estudiantes/Archivos/Material_Educativo/archivo1.pdf
touch Incos/Estudiantes/Archivos/Material_Educativo/archivo2.pdf
touch Incos/Estudiantes/Archivos/Material_Educativo/archivo3.pdf
touch Incos/Estudiantes/Archivos/Material_Educativo/archivo4.pdf
# Comandos para resolver el examen       
sudo groupadd Maestros
sudo groupadd Alumnos
sudo useradd jramos -g Maestros -p holamundo
sudo useradd aperedo -g Alumnos -p holamundo
sudo chown :Maestros ~/Incos/Docentes
sudo chown :Alumnos ~/Incos/Estudiantes