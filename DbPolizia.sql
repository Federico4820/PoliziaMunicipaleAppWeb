CREATE TABLE ANAGRAFICA (
    idanagrafica INT PRIMARY KEY,
    Cognome VARCHAR(50) NOT NULL,
    Nome VARCHAR(50) NOT NULL,
    Indirizzo VARCHAR(100),
    Città VARCHAR(50),
    CAP VARCHAR(10),
    Cod_Fisc VARCHAR(16)
);

CREATE TABLE TIPO_VIOLAZIONE (
    idviolazione INT PRIMARY KEY,
    descrizione VARCHAR(255) NOT NULL
);

CREATE TABLE VERBALE (
    idverbale INT PRIMARY KEY,
    idanagrafica INT,           
    idviolazione INT,           
    DataViolazione DATE,
    IndirizzoViolazione VARCHAR(100),
    Nominativo_Agente VARCHAR(100),
    DataTrascrizioneVerbale DATE,
    Importo DECIMAL(10,2),
    DecurtamentoPunti INT,
    CONSTRAINT FK_Anagrafica FOREIGN KEY (idanagrafica)
        REFERENCES ANAGRAFICA(idanagrafica),
    CONSTRAINT FK_Violazione FOREIGN KEY (idviolazione)
        REFERENCES TIPO_VIOLAZIONE(idviolazione)
);