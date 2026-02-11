DELIMITER //

CREATE FUNCTION obtener_info_provincia(id_prov INT)
RETURNS TEXT
BEGIN
    DECLARE result TEXT DEFAULT '';
    DECLARE done INT DEFAULT FALSE;
    DECLARE id_municipio, cant_salud, cant_industria, cant_publicos, total_establecimientos INT;
    DECLARE nombre_municipio VARCHAR(30);
    DECLARE promedio_antiguedad DECIMAL(10,2);
    DECLARE municipio_count INT;
    
    -- Obtener el nombre de la provincia
    SELECT CONCAT('Provincia: ', nombreProvincia) INTO result FROM provincia WHERE idProvincia = id_prov;
    
    -- Obtener la cantidad de municipios en la provincia
    SELECT COUNT(*) INTO municipio_count FROM municipio WHERE idProvincia = id_prov;
    
    -- Inicializar la variable para concatenar los resultados
    SET result = CONCAT(result, '\n\n');
    
    -- Inicializar el contador para el ciclo WHILE
    SET id_municipio = 1;
    
    -- Iniciar el ciclo para recorrer los municipios
    municipios_loop: WHILE id_municipio <= municipio_count DO
        
        -- Obtener el nombre del municipio actual
        SELECT nombreMunicipio INTO nombre_municipio FROM municipio WHERE idProvincia = id_prov AND idMunicipio = id_municipio;
        
        -- Resetear las variables para contar los establecimientos
        SET cant_salud = 0;
        SET cant_industria = 0;
        SET cant_publicos = 0;
        
        -- Obtener la cantidad de establecimientos de salud en el municipio
        SELECT COUNT(*) INTO cant_salud FROM establecimientosalud WHERE idEstablecimientoSalud IN (
            SELECT idEstablecimiento FROM establecimiento WHERE idMunicipio = id_municipio
        );
        
        -- Obtener la cantidad de establecimientos de industria en el municipio
        SELECT COUNT(*) INTO cant_industria FROM establecimientoindustria WHERE idEstablecimientoIndustria IN (
            SELECT idEstablecimiento FROM establecimiento WHERE idMunicipio = id_municipio
        );
        
        -- Obtener la cantidad de establecimientos públicos en el municipio
        SELECT COUNT(*) INTO cant_publicos FROM establecimiento WHERE idMunicipio = id_municipio AND idEstablecimiento NOT IN (
            SELECT idEstablecimiento FROM establecimientosalud
            UNION
            SELECT idEstablecimiento FROM establecimientoindustria
        );
        
        -- Calcular la cantidad total de establecimientos
        SET total_establecimientos = cant_salud + cant_industria + cant_publicos;
        
        -- Calcular el promedio de años de antigüedad de los establecimientos en el municipio
        SELECT AVG(DATEDIFF(CURDATE(), fechaApertura) / 365) INTO promedio_antiguedad FROM establecimiento WHERE idMunicipio = id_municipio;
        
        -- Concatenar la información del municipio al resultado
        SET result = CONCAT(
            result,
            'Municipio: ', nombre_municipio, '\n',
            'Cantidad de Establecimientos de Salud: ', cant_salud, '\n',
            'Cantidad de Establecimientos de Industria: ', cant_industria, '\n',
            'Cantidad de Establecimientos Públicos: ', cant_publicos, '\n',
            'Cantidad Total de Establecimientos: ', total_establecimientos, '\n',
            'Razón: ',
                CASE WHEN cant_publicos > 0 THEN (cant_salud + cant_industria) / cant_publicos ELSE 0 END, '\n',
            'Promedio de Años de Antigüedad: ', promedio_antiguedad, '\n\n'
        );
        
        -- Incrementar el contador de municipios
        SET id_municipio = id_municipio + 1;
        
    END WHILE municipios_loop;
    
    -- Si no se encontraron municipios, indicar "SIN MUNICIPIOS"
    IF LENGTH(result) = 0 THEN
        SET result = CONCAT('Provincia: SIN MUNICIPIOS');
    END IF;
    
    RETURN result;
    
END //

DELIMITER ;
