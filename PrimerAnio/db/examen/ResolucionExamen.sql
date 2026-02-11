USE `bdempresas`;

DROP FUNCTION IF EXISTS ufcExamen;

DELIMITER $$

CREATE FUNCTION ufcExamen(_id INT) 
RETURNS VARCHAR(65000) DETERMINISTIC
BEGIN
    DECLARE _res VARCHAR(65000) DEFAULT 'ID Inexistente';
    DECLARE _iniM, _finM INT;
    DECLARE _cantSalud, _cantIndustria, _cantPublico, _idM, _totalE INT;
    DECLARE _prom DECIMAL(18,2) DEFAULT 0;

    IF EXISTS(SELECT idProvincia FROM provincia WHERE idProvincia=_id) THEN
        SELECT nombreProvincia INTO _res 
        FROM provincia 
        WHERE idProvincia=_id;
        
        SELECT IFNULL(MIN(idMunicipio), 0), IFNULL(MAX(idMunicipio), 0) INTO _iniM, _finM 
        FROM municipio
        WHERE idProvincia=_id;

        IF _iniM = 0 AND _finM = 0 THEN
            SET _res = CONCAT(_res, ' - SIN MUNICIPIOS');
        END IF;

        SET _res = CONCAT(_res, '\n\n');

        WHILE _iniM <= _finM DO
            IF EXISTS(SELECT idMunicipio FROM municipio WHERE idMunicipio=_iniM AND idProvincia=_id) THEN
                SELECT CONCAT(_res, '*', nombreMunicipio, '\n'), idMunicipio INTO _res, _idM 
                FROM municipio 
                WHERE idMunicipio=_iniM;
                
                SELECT COUNT(E.idEstablecimiento) INTO _cantSalud
                FROM establecimiento E 
                INNER JOIN establecimientosalud Es ON E.idEstablecimiento=Es.idEstablecimientoSalud 
                WHERE E.idMunicipio=_idM;
                
                SELECT COUNT(E.idEstablecimiento) INTO _cantIndustria
                FROM establecimiento E 
                INNER JOIN establecimientoindustria Ei ON E.idEstablecimiento=Ei.idEstablecimientoIndustria 
                WHERE E.idMunicipio=_idM;
                
                SELECT AVG(2024-YEAR(E.fechaApertura)) INTO _prom
                FROM establecimiento E 
                WHERE E.idMunicipio=_idM;
                
                SELECT COUNT(idEstablecimiento) INTO _totalE
                FROM establecimiento
                WHERE idMunicipio=_idM;

                IF _totalE > 0 THEN
                    SET _cantPublico = _totalE - _cantSalud - _cantIndustria;
                    SET _res = CONCAT(_res, 
                        '-', 'Cantidad Establecimientos de Salud: ', _cantSalud, '\n',
                        '-', 'Cantidad Establecimientos Industria: ', _cantIndustria, '\n',
                        '-', 'Cantidad de Establecimientos Públicos: ', _cantPublico, '\n',
                        '-', 'Cantidad Total de Establecimientos: ', _totalE, '\n',
                        '-', 'Razón: ', IFNULL((_cantSalud + _cantIndustria) / _cantPublico, 0), '\n',
                        '-', 'Promedio de Años de Antigüedad: ', IFNULL(_prom, 0), '\n\n'
                    );
                END IF;

                IF _totalE = 0 THEN
                    SET _res = CONCAT(_res, '- SIN ESTABLECIMIENTOS', '\n\n');
                END IF;
            END IF;

            SET _iniM = _iniM + 1;
        END WHILE;
    END IF;

    RETURN _res;
END$$

DELIMITER ;

-- Ejecutar la función con un ejemplo
SELECT ufcExamen(9);

-- Consultas adicionales para verificar datos
SELECT * FROM provincia;

SELECT * 
FROM municipio
ORDER BY idMunicipio;

SELECT *
FROM establecimiento
WHERE idMunicipio = 8;
