CREATE DATABASE IF NOT EXISTS gastosdb;
USE gastosdb;

CREATE TABLE gastos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    descripcion VARCHAR(200) NOT NULL,
    tipo_gasto VARCHAR(50) NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    fecha DATE NOT NULL,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_fecha (fecha),
    INDEX idx_tipo_gasto (tipo_gasto)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO gastos (descripcion, tipo_gasto, monto, fecha) VALUES
('Lapices', 'Artículos de oficina', 10.00, '2025-11-07'),
('Almuerzo', 'Comida', 45.50, '2025-11-23'),
('Gasolina', 'Transporte', 150.00, '2025-11-22'),
('Cine', 'Entretenimiento', 60.00, '2025-11-20');

SELECT * FROM gastos ORDER BY fecha DESC;

SELECT tipo_gasto, SUM(monto) as total 
FROM gastos 
GROUP BY tipo_gasto;

SELECT * FROM gastos 
WHERE MONTH(fecha) = MONTH(CURRENT_DATE()) 
AND YEAR(fecha) = YEAR(CURRENT_DATE())
ORDER BY fecha DESC;

SELECT SUM(monto) as total_gastos FROM gastos;