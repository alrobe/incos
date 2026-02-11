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



        -- Incrementar el contador de municipios
        SET id_municipio = id_municipio + 1;

    END WHILE municipios_loop;
    
    RETURN result;
    
END //

DELIMITER ;
