DELIMITER $$

CREATE FUNCTION ufcExamen(_id INT) 
RETURNS VARCHAR(65000) DETERMINISTIC
BEGIN
    DECLARE _res VARCHAR(65000) DEFAULT 'ID Inexistente';
    DECLARE _iniM, _finM INT;
    DECLARE _idM, _totalE INT;
    DECLARE _cantSalud, _cantIndustria INT;

    -- Verificar si existe la provincia con el ID proporcionado
    IF EXISTS(SELECT idProvincia FROM provincia WHERE idProvincia = _id) THEN
        -- Obtener el nombre de la provincia
        SELECT nombreProvincia INTO _res 
        FROM provincia 
        WHERE idProvincia = _id;

        -- Obtener los límites del rango de municipios para la provincia
        SELECT IFNULL(MIN(idMunicipio), 0), IFNULL(MAX(idMunicipio), 0) INTO _iniM, _finM 
        FROM municipio
        WHERE idProvincia = _id;

        -- Si no hay municipios en la provincia, añadir mensaje correspondiente
        IF _iniM = 0 AND _finM = 0 THEN
            SET _res = CONCAT(_res, ' - SIN MUNICIPIOS');
        END IF;

        -- Recorrer los municipios dentro del rango obtenido
        WHILE _iniM <= _finM DO
            -- Verificar si existe el municipio específico
            IF EXISTS(SELECT idMunicipio FROM municipio WHERE idMunicipio = _iniM AND idProvincia = _id) THEN
                -- Obtener el nombre del municipio
                SELECT nombreMunicipio INTO _res FROM municipio WHERE idMunicipio = _iniM;
                
                -- Contar los establecimientos de salud en el municipio
                SELECT COUNT(E.idEstablecimiento) INTO _cantSalud
                FROM establecimiento E 
                INNER JOIN establecimientosalud Es ON E.idEstablecimiento = Es.idEstablecimientoSalud 
                WHERE E.idMunicipio = _iniM;

                -- Contar los establecimientos de industria en el municipio
                SELECT COUNT(E.idEstablecimiento) INTO _cantIndustria
                FROM establecimiento E 
                INNER JOIN establecimientoindustria Ei ON E.idEstablecimiento = Ei.idEstablecimientoIndustria 
                WHERE E.idMunicipio = _iniM;

                -- Calcular el total de establecimientos en el municipio
                SELECT COUNT(idEstablecimiento) INTO _totalE
                FROM establecimiento
                WHERE idMunicipio = _iniM;

                -- Construir la parte del resultado con la información del municipio
                SET _res = CONCAT(_res, 
                    ' - Cantidad Establecimientos de Salud: ', _cantSalud,
                    ' - Cantidad Establecimientos de Industria: ', _cantIndustria, 
                    ' - Cantidad de Establecimientos Públicos: ', (_totalE - _cantSalud - _cantIndustria),
                    ' - Cantidad Total de Establecimientos: ', _totalE
                );
            END IF;
            
            -- Incrementar el ID del municipio para avanzar en el bucle
            SET _iniM = _iniM + 1;
        END WHILE;
    END IF;

    -- Retornar el resultado construido
    RETURN _res;
END$$

DELIMITER ;
