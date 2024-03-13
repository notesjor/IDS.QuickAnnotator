# Dokumentation

- Grundlage sind die Daten der Annotationsrunde 18/19 (IDS Genderlinguistik - DPA-Studie).
- Folgende Layer müssen für beide Annotator*innen übereinstimmen:
	- LK (Linguistische Klasse) = 1 -> nominale Personenbezeichnungen
	- Generisches Maskulinum = true -> dies führt zur Annotation 1 in der Spalte "Generisches Maskulinum"
	- 1-Wert in der Spalte "Spezisches Maskulinum" bedeutet:
		- Für 18:
			- "Welches Geschlecht?" = "male"
			- "Gelechtsabstrahierendes Substantiv" != "true"
			- "Lexem mit Genus-Sexus-Kongruenz?" != "true"
		- Für 19:
			- "Welches Geschlecht?" = "male"
			- Die anderen Layer wurden nach einer Änderung des Schemas nicht erhoben
	- 1-Wert in der Spalte "Spezisches Femininum" bedeutet: "Bereits gegendert/moviert" = "Ja"

## Aufbau der Daten
- Pro Runde gibt es einen Ordner
- Jeder Ordner enthält eine data.tsv - Diese utf-8 encodierte TSV-Datei beinhaltet folgende Spalten:
	- GUID - Diese Spalte enhält die GUID bereits als fertigen Dateinamen. Die Dateien sind im Ordner docs zu finden.
	- SatzID - Dies ist der 0-basierte Index in der Datei (siehe unten).
	- Wort - Das annotierte Token.
	- Generisches Maskulinum - 1 oder 0
	- Spezisches Maskulinum - 1 oder 0
	- Spezisches Femininum - 1 oder 0
- Jeder Ordner enthält einen Unterordner mit den Dokumenten. Jeder Satz (SatzID) ist in eine separate Zeile (\r\n getrennt) geschrieben. Token sind mit Leerzeichen separiert. Bitte einfachen Space-Tokenizer nutzen.