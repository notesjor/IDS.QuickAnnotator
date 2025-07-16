# IDS.QuickAnnotator

## Projektübersicht (Deutsch) - [English project description see below]

IDS.QuickAnnotator ist ein umfassendes, modular aufgebautes System zur effizienten, transparenten und reproduzierbaren Annotation von Textkorpora. Ziel des Projekts ist es, den gesamten Workflow von der Auswahl und Vorbereitung der Texte über die eigentliche Annotation bis hin zur Auswertung und Konvertierung der Ergebnisse zu unterstützen und zu automatisieren.

Das System besteht aus mehreren spezialisierten Komponenten, die jeweils einen klar abgegrenzten Aufgabenbereich abdecken:

- **IDS.QuickAnnotator.API**  
  Die zentrale Server-Komponente stellt eine REST-basierte Web-API bereit, über die sämtliche Annotationen, Annotations-Jobs und Nutzerinteraktionen verwaltet werden. Sie sorgt für die Konsistenz der Daten und ermöglicht die Integration externer Tools und Clients.

- **IDS.QuickAnnotator.Client**  
  Die Hauptoberfläche für Annotatoren bietet eine intuitive Benutzerführung und unterstützt die individuelle Bearbeitung und Verwaltung von Annotationen. Jeder Nutzer arbeitet mit eigenen Annotationen, wodurch eine klare Trennung und Nachvollziehbarkeit gewährleistet ist.

- **IDS.QuickAnnotator.Client.Selector**  
  Dieses Tool unterstützt Hilfskraftbetreuer bei der Vorauswahl von Texten. Mithilfe von statistischem Sampling können gezielt relevante Textausschnitte für die Annotation zusammengestellt werden, um eine ausgewogene und repräsentative Stichprobe zu gewährleisten.

- **IDS.QuickAnnotator.CorpusPreSampler**  
  Das Presampling-Modul automatisiert die statistische Vorauswahl und Bereinigung von Texten. Es bereitet die Daten für den IDS.QuickAnnotator.Client.Selector vor und stellt sicher, dass die zu annotierenden Texte den gewünschten Kriterien entsprechen.

- **IDS.QuickAnnotator.Processor**  
  Dieses Modul konvertiert verschiedene Korpusformate (z. B. KorAP) in ein einheitliches, von der API verarbeitbares Format. Dadurch können unterschiedlich strukturierte Ausgangsdaten problemlos integriert und weiterverarbeitet werden.

- **IDS.QuickAnnotator.QafSampler**  
  Der QafSampler ermöglicht eine quotenbasierte Auswahl von Texten, um bestimmte Kriterien oder Verteilungen innerhalb des Korpus gezielt abzubilden und die Zusammensetzung der Stichprobe zu steuern.

- **IDS.QuickAnnotator.Tool4.AnnotatedBy**  
  Mit diesem Analyse-Tool lässt sich nachvollziehen, welche Texte und Textstellen von welchen Personen annotiert wurden. Es unterstützt die Qualitätssicherung, die Auswertung der Annotationen und die Dokumentation der Arbeitsprozesse.

- **IDS.QuickAnnotator.Tool4.ApplyAnnotatorFixes**  
  Dieses Tool dient dazu, nachträgliche Korrekturen und Anpassungen an bestehenden Annotationen vorzunehmen, etwa um Fehler zu beheben oder die Datenqualität zu erhöhen.

- **IDS.QuickAnnotator.Tool4.CalcDiff**  
  Das Berichtstool erstellt Auswertungen zu abgeschlossenen Annotationen, darunter Interannotator Agreement, DIFF-Ansichten im HTML-Format und Analyse-Diagramme zur Visualisierung der Ergebnisse. So können Unterschiede und Übereinstimmungen zwischen Annotatoren systematisch erfasst werden.

- **IDS.QuickAnnotator.Tool4.ConvertToCorpus**  
  Nach Abschluss der Annotationen können die Korpora mit diesem Tool in verschiedene Zielformate (z. B. KorAP) konvertiert werden, um sie für weitere Analysen oder externe Anwendungen bereitzustellen.

- **IDS.QuickAnnotator.Tool4.ConvertToJournal**  
  Dieses Modul konvertiert die annotierten Korpora in ein internes Journal-Format, das für spezifische Workflows und Dokumentationszwecke innerhalb des Projekts genutzt wird.

- **IDS.QuickAnnotator.Tool4.DominicSchmitz**  
  Ein spezielles Konvertierungstool für die Zusammenarbeit mit mit Dominic Schmitz.

- **IDS.QuickAnnotator.Tool4.FindMatchSentences**  
  Mit diesem Tool können übereinstimmende Sätze in verschiedenen annotierten Korpora gefunden und verglichen werden, was die Konsistenzprüfung und Qualitätssicherung erleichtert.

- **IDS.QuickAnnotator.Tool4.OnlyAnnotatedBy**  
  Dieses Analyse-Tool identifiziert Annotationen, die ausschließlich von einem bestimmten Annotator erstellt wurden, und unterstützt so die gezielte Auswertung individueller Beiträge und die Überprüfung der Annotationstiefe.

- **IDS.QuickAnnotator.Tool4.RemoveAnnotator**  
  Ermöglicht das nachträgliche Entfernen von Annotationen, beispielsweise wenn ein Annotator ausfällt oder Daten bereinigt werden müssen.

- **IDS.QuickAnnotator.Web**  
  Die Web-Version des Clients befindet sich aktuell im Beta-Stadium und bietet eine moderne, browserbasierte Oberfläche für die Annotation. Sie ermöglicht ortsunabhängiges Arbeiten und eine einfache Integration in bestehende Workflows.

Alle Komponenten sind in separaten Unterordnern organisiert und greifen über klar definierte Schnittstellen ineinander. Die modulare Architektur erlaubt eine flexible Erweiterung und Anpassung an unterschiedliche Anforderungen und Korpusformate. So entsteht eine skalierbare Infrastruktur, die den gesamten Prozess von der Auswahl und Konvertierung der Texte bis zur Analyse und Auswertung der Annotationen abdeckt und eine hohe Datenqualität sowie Nachvollziehbarkeit sicherstellt.

## project description (Englisch)

IDS.QuickAnnotator is a comprehensive, modular system for the efficient, transparent, and reproducible annotation of text corpora. The aim of the project is to support and automate the entire workflow, from the selection and preparation of texts to the actual annotation and evaluation and conversion of the results.

The system consists of several specialized components, each covering a clearly defined area of responsibility:

- **IDS.QuickAnnotator.API**
The central server component provides a REST-based web API that manages all annotations, annotation jobs, and user interactions. It ensures data consistency and enables the integration of external tools and clients.

- **IDS.QuickAnnotator.Client**  
  The main interface for annotators offers intuitive user guidance and supports individual editing and management of annotations. Each user works with their own annotations, ensuring clear separation and traceability.

- **IDS.QuickAnnotator.Client.Selector**  
  This tool supports assistant supervisors in the preselection of texts. With the help of statistical sampling, relevant text excerpts can be compiled for annotation in order to ensure a balanced and representative sample.

- **IDS.QuickAnnotator.CorpusPreSampler**
The presampling module automates the statistical preselection and cleaning of texts. It prepares the data for the IDS.QuickAnnotator.Client.Selector and ensures that the texts to be annotated meet the desired criteria.

- **IDS.QuickAnnotator.Tool4.AnnotatedBy**  
  This analysis tool allows you to track which texts and text passages have been annotated by which individuals. It supports quality assurance, the evaluation of annotations, and the documentation of work processes.

- **IDS.QuickAnnotator.Tool4.ApplyAnnotatorFixes**  
  This tool is used to make subsequent corrections and adjustments to existing annotations, for example to fix errors or improve data quality.

- **IDS.QuickAnnotator.Tool4.CalcDiff**
The reporting tool generates evaluations of completed annotations, including interannotator agreement, DIFF views in HTML format, and analysis diagrams for visualizing the results. This allows differences and similarities between annotators to be systematically recorded.

- **IDS.QuickAnnotator.Tool4.ConvertToCorpus**  
  Once the annotations are complete, this tool can be used to convert the corpora into various target formats (e.g., KorAP) in order to make them available for further analysis or external applications.

- **IDS.QuickAnnotator.Tool4.ConvertToJournal**
This module converts the annotated corpora into an internal journal format that is used for specific workflows and documentation purposes within the project.

- **IDS.QuickAnnotator.Tool4.DominicSchmitz**  
  A special conversion tool for collaboration with Dominic Schmitz.

- **IDS.QuickAnnotator.Tool4.FindMatchSentences**
This tool can be used to find and compare matching sentences in different annotated corpora, which facilitates consistency checking and quality assurance.

- **IDS.QuickAnnotator.Tool4.OnlyAnnotatedBy**  
  This analysis tool identifies annotations that were created exclusively by a specific annotator, thereby supporting the targeted evaluation of individual contributions and the review of annotation depth.

- **IDS.QuickAnnotator.Tool4.RemoveAnnotator**  
  Enables annotations to be removed retrospectively, for example if an annotator is unavailable or data needs to be cleaned up.

- **IDS.QuickAnnotator.Web**  
  The web version of the client is currently in beta and offers a modern, browser-based interface for annotation. It enables location-independent working and easy integration into existing workflows.

All components are organized in separate subfolders and interact via clearly defined interfaces. The modular architecture allows for flexible expansion and adaptation to different requirements and corpus formats. This creates a scalable infrastructure that covers the entire process from text selection and conversion to annotation analysis and evaluation, ensuring high data quality and traceability.