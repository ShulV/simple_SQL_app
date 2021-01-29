# simple_SQL_app
Authorization and registration. Data is stored in database MySql (project winforms)
-----------------------------------------------------------------------------------
MySQL СПРАВКА
Настройки в phpMyAdmin:
- сопоставление кодировки соединения = utf8mb4_unicode_ci (стандарт)
- при создании базы выбрать кодировку = utf8_general_ci (стандарт)
- при создании таблицы:
  - для уникального идентификатора (id): тип=int, длина=11, атрибуты=UNSIGNED, индекс=UNIQUE, A_I=true
  - для текстовых данных: тип=VARCHAR, длина=100, сравнение=utf8_general_ci
  - для всей таблицы: сравнение=utf8_general_ci, тип таблицы=MyISAM
