using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using IDS.QuickAnnotator.API.Model.Request;
using IDS.QuickAnnotator.Client.Controls;
using IDS.QuickAnnotator.Client.Forms.Abstract;
using IDS.QuickAnnotator.Client.Model;
using IDS.QuickAnnotator.Client.Model.Annotation;
using IDS.QuickAnnotator.Client.Model.Steps;
using IDS.QuickAnnotator.Client.Model.User;
using IDS.QuickAnnotator.Client.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IDS.QuickAnnotator.Client.Forms
{
  public partial class DashboardForm : AbstractForm
  {
    private Editor _editor = new Editor();
    private readonly AnnotationModelOnline _anno;
    private readonly UserModel _user;
    private bool _init = true;

    public DashboardForm()
    {
      InitializeComponent();
      cmb_text.CommandBarDropDownListElement.TextBox.Margin = new Padding(0, 6, 0, 0);
      cmb_text.CommandBarDropDownListElement.TextBox.TextBoxItem.ReadOnly = true;
      commandBarStripElement1.OverflowButton.Visibility = ElementVisibility.Collapsed;

      #region EDITOR
      _editor.Height = elementHost1.Height;
      _editor.Width = elementHost1.Width;
      _editor.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      _editor.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      _editor.LeftClick += EditorOnLeftClick;
      _editor.RightClick += EditorOnRightClick;
      //_editor.Highlight = new HashSet<string> { };
      _editor.Highlight = new HashSet<string>
      {
        "Altenpfleger", "Altenpflegers", "Altenpflegern", "Altenpflegerin", "Altenpflegerinnen", "Altenpfleger:in", "Altenpfleger:innen", "Altenpfleger*in", "Altenpfleger*innen", "Altenpfleger:", "Altenpfleger*", "Anwalt", "Anwalts", "Anwälte", "Anwälten", "Anwältin", "Anwältinnen", "Anwält:in", "Anwält:innen", "Anwält*in", "Anwält*innen", "Anwält:", "Anwält*", "Anwält", "Apotheker", "Apothekers", "Apothekern", "Apothekerin", "Apothekerinnen", "Apotheker:in", "Apotheker:innen", "Apotheker*in", "Apotheker*innen", "Apotheker:", "Apotheker*", "Arbeitnehmer", "Arbeitnehmers", "Arbeitnehmern", "Arbeitnehmerin", "Arbeitnehmerinnen", "Arbeitnehmer:in", "Arbeitnehmer:innen", "Arbeitnehmer*in", "Arbeitnehmer*innen", "Arbeitnehmer:", "Arbeitnehmer*", "Architekt", "Architekts", "Architekten", "Architektin", "Architektinnen", "Architekt:in", "Architekt:innen", "Architekt*in", "Architekt*innen", "Architekt:", "Architekt*", "Arzt", "Arztes", "Ärzte", "Ärzten", "Ärztin", "Ärztinnen", "Ärzt:in", "Ärzt:innen", "Ärzt*in", "Ärzt*innen", "Ärzt:", "Ärzt*", "Ärzt", "Arzthelfer", "Arzthelfers", "Arzthelfern", "Arzthelferin", "Arzthelferinnen", "Arzthelfer:in", "Arzthelfer:innen", "Arzthelfer*in", "Arzthelfer*innen", "Arzthelfer:", "Arzthelfer*", "Assistent", "Assistenten", "Assistentin", "Assistentinnen", "Assistent:in", "Assistent:innen", "Assistent*in", "Assistent*innen", "Assistent:", "Assistent*", "Autofahrer", "Autofahrers", "Autofahrern", "Autofahrerin", "Autofahrerinnen", "Autofahrer:in", "Autofahrer:innen", "Autofahrer*in", "Autofahrer*innen", "Autofahrer:", "Autofahrer*", "Automechaniker", "Automechanikers", "Automechanikern", "Automechanikerin", "Automechanikerinnen", "Automechaniker:in", "Automechaniker:innen", "Automechaniker*in", "Automechaniker*innen", "Automechaniker:", "Automechaniker*", "Bäcker", "Bäckers", "Bäckern", "Bäckerin", "Bäckerinnen", "Bäcker:in", "Bäcker:innen", "Bäcker*in", "Bäcker*innen", "Bäcker:", "Bäcker*", "Barkeeper", "Barkeepers", "Barkeepern", "Barkeeperin", "Barkeeperinnen", "Barkeeper:in", "Barkeeper:innen", "Barkeeper*in", "Barkeeper*innen", "Barkeeper:", "Barkeeper*", "Bauingenieur", "Bauingenieurs", "Bauingenieure", "Bauingenieuren", "Bauingenieurin", "Bauingenieurinnen", "Bauingenieur:in", "Bauingenieur:innen", "Bauingenieur*in", "Bauingenieur*innen", "Bauingenieur:", "Bauingenieur*", "Bestatter", "Bestatters", "Bestattern", "Bestatterin", "Bestatterinnen", "Bestatter:in", "Bestatter:innen", "Bestatter*in", "Bestatter*innen", "Bestatter:", "Bestatter*", "Besucher", "Besuchers", "Besuchern", "Besucherin", "Besucherinnen", "Besucher:in", "Besucher:innen", "Besucher*in", "Besucher*innen", "Besucher:", "Besucher*", "Bibliothekar", "Bibliothekars", "Bibliothekare", "Bibliothekaren", "Bibliothekarin", "Bibliothekarinnen", "Bibliothekar:in", "Bibliothekar:innen", "Bibliothekar*in", "Bibliothekar*innen", "Bibliothekar:", "Bibliothekar*", "Börsenmakler", "Börsenmaklers", "Börsenmaklern", "Börsenmaklerin", "Börsenmaklerinnen", "Börsenmakler:in", "Börsenmakler:innen", "Börsenmakler*in", "Börsenmakler*innen", "Börsenmakler:", "Börsenmakler*", "Bürger", "Bürgers", "Bürgern", "Bürgerin", "Bürgerinnen", "Bürger:in", "Bürger:innen", "Bürger*in", "Bürger*innen", "Bürger:", "Bürger*", "Bürgermeister", "Bürgermeisters", "Bürgermeistern", "Bürgermeisterin", "Bürgermeisterinnen", "Bürgermeister:in", "Bürgermeister:innen", "Bürgermeister*in", "Bürgermeister*innen", "Bürgermeister:", "Bürgermeister*", "Busfahrer", "Busfahrers", "Busfahrern", "Busfahrerin", "Busfahrerinnen", "Busfahrer:in", "Busfahrer:innen", "Busfahrer*in", "Busfahrer*innen", "Busfahrer:", "Busfahrer*", "Chef", "Chefs", "Chefin", "Chefinnen", "Chef:in", "Chef:innen", "Chef*in", "Chef*innen", "Chef:", "Chef*", "Chirurg", "Chirurgs", "Chirurgen", "Chirurgin", "Chirurginnen", "Chirurg:in", "Chirurg:innen", "Chirurg*in", "Chirurg*innen", "Chirurg:", "Chirurg*", "Dachdecker", "Dachdeckers", "Dachdeckern", "Dachdeckerin", "Dachdeckerinnen", "Dachdecker:in", "Dachdecker:innen", "Dachdecker*in", "Dachdecker*innen", "Dachdecker:", "Dachdecker*", "Erzieher", "Erziehers", "Erziehern", "Erzieherin", "Erzieherinnen", "Erzieher:in", "Erzieher:innen", "Erzieher*in", "Erzieher*innen", "Erzieher:", "Erzieher*", "Fitnesstrainer", "Fitnesstrainers", "Fitnesstrainern", "Fitnesstrainerin", "Fitnesstrainerinnen", "Fitnesstrainer:in", "Fitnesstrainer:innen", "Fitnesstrainer*in", "Fitnesstrainer*innen", "Fitnesstrainer:", "Fitnesstrainer*", "Florist", "Florists", "Floristen", "Floristin", "Floristinnen", "Florist:in", "Florist:innen", "Florist*in", "Florist*innen", "Florist:", "Florist*", "Flugbegleiter", "Flugbegleiters", "Flugbegleitern", "Flugbegleiterin", "Flugbegleiterinnen", "Flugbegleiter:in", "Flugbegleiter:innen", "Flugbegleiter*in", "Flugbegleiter*innen", "Flugbegleiter:", "Flugbegleiter*", "Fotograf", "Fotografs", "Fotografen", "Fotografin", "Fotografinnen", "Fotograf:in", "Fotograf:innen", "Fotograf*in", "Fotograf*innen", "Fotograf:", "Fotograf*", "Frauenarzt", "Frauenarztes", "Frauenärzte", "Frauenärzten", "Frauenärztin", "Frauenärztinnen", "Frauenärzt:in", "Frauenärzt:innen", "Frauenärzt*in", "Frauenärzt*innen", "Frauenärzt:", "Frauenärzt*", "Frauenärzt", "Freund", "Freunds/Freundes", "Freunde", "Freunden", "Freundin", "Freundinnen", "Freund:in", "Freund:innen", "Freund*in", "Freund*innen", "Freund:", "Freund*", "Friseur", "Friseurs", "Friseure", "Friseuren", "Friseurin", "Friseurinnen", "Friseur:in", "Friseur:innen", "Friseur*in", "Friseur*innen", "Friseur:", "Friseur*", "Fußgänger", "Fußgängers", "Fußgängern", "Fußgängerin", "Fußgängerinnen", "Fußgänger:in", "Fußgänger:innen", "Fußgänger*in", "Fußgänger*innen", "Fußgänger:", "Fußgänger*", "Gamer", "Gamers", "Gamern", "Gamerin", "Gamerinnen", "Gamer:in", "Gamer:innen", "Gamer*in", "Gamer*innen", "Gamer:", "Gamer*", "Gastgeber", "Gastgebers", "Gastgebern", "Gastgeberin", "Gastgeberinnen", "Gastgeber:in", "Gastgeber:innen", "Gastgeber*in", "Gastgeber*innen", "Gastgeber:", "Gastgeber*", "Grafikdesigner", "Grafikdesigners", "Grafikdesignern", "Grafikdesignerin", "Grafikdesignerinnen", "Grafikdesigner:in", "Grafikdesigner:innen", "Grafikdesigner*in", "Grafikdesigner*innen", "Grafikdesigner:", "Grafikdesigner*", "Grundschullehrer", "Grundschullehrers", "Grundschullehrern", "Grundschullehrerin", "Grundschullehrerinnen", "Grundschullehrer:in", "Grundschullehrer:innen", "Grundschullehrer*in", "Grundschullehrer*innen", "Grundschullehrer:", "Grundschullehrer*", "Gymnasiallehrer", "Gymnasiallehrers", "Gymnasiallehrern", "Gymnasiallehrerin", "Gymnasiallehrerinnen", "Gymnasiallehrer:in", "Gymnasiallehrer:innen", "Gymnasiallehrer*in", "Gymnasiallehrer*innen", "Gymnasiallehrer:", "Gymnasiallehrer*", "Handwerker", "Handwerkers", "Handwerkern", "Handwerkerin", "Handwerkerinnen", "Handwerker:in", "Handwerker:innen", "Handwerker*in", "Handwerker*innen", "Handwerker:", "Handwerker*", "Hausmeister", "Hausmeisters", "Hausmeistern", "Hausmeisterin", "Hausmeisterinnen", "Hausmeister:in", "Hausmeister:innen", "Hausmeister*in", "Hausmeister*innen", "Hausmeister:", "Hausmeister*", "Hilfsarbeiter", "Hilfsarbeiters", "Hilfsarbeitern", "Hilfsarbeiterin", "Hilfsarbeiterinnen", "Hilfsarbeiter:in", "Hilfsarbeiter:innen", "Hilfsarbeiter*in", "Hilfsarbeiter*innen", "Hilfsarbeiter:", "Hilfsarbeiter*", "Ingenieur", "Ingenieurs", "Ingenieure", "Ingenieuren", "Ingenieurin", "Ingenieurinnen", "Ingenieur:in", "Ingenieur:innen", "Ingenieur*in", "Ingenieur*innen", "Ingenieur:", "Ingenieur*", "Jogger", "Joggers", "Joggern", "Joggerin", "Joggerinnen", "Jogger:in", "Jogger:innen", "Jogger*in", "Jogger*innen", "Jogger:", "Jogger*", "Journalist", "Journalisten", "Journalistin", "Journalistinnen", "Journalist:in", "Journalist:innen", "Journalist*in", "Journalist*innen", "Journalist:", "Journalist*", "Jurist", "Juristen", "Juristin", "Juristinnen", "Jurist:in", "Jurist:innen", "Jurist*in", "Jurist*innen", "Jurist:", "Jurist*", "Kassierer", "Kassierers", "Kassierern", "Kassiererin", "Kassiererinnen", "Kassierer:in", "Kassierer:innen", "Kassierer*in", "Kassierer*innen", "Kassierer:", "Kassierer*", "Kellner", "Kellners", "Kellnern", "Kellnerin", "Kellnerinnen", "Kellner:in", "Kellner:innen", "Kellner*in", "Kellner*innen", "Kellner:", "Kellner*", "Koch", "Kochs/Koches", "Köche", "Köchen", "Köchin", "Köchinnen", "Köch:in", "Köch:innen", "Köch*in", "Köch*innen", "Köch:", "Köch*", "Köch", "Kollege", "Kollegen", "Kollegin", "Kolleginnen", "Kolleg:in", "Kolleg:innen", "Kolleg*in", "Kolleg*innen", "Kolleg:", "Kolleg*", "Kolleg", "Kosmetiker", "Kosmetikers", "Kosmetikern", "Kosmetikerin", "Kosmetikerinnen", "Kosmetiker:in", "Kosmetiker:innen", "Kosmetiker*in", "Kosmetiker*innen", "Kosmetiker:", "Kosmetiker*", "Krankenpfleger", "Krankenpflegers", "Krankenpflegern", "Krankenpflegerin", "Krankenpflegerinnen", "Krankenpfleger:in", "Krankenpfleger:innen", "Krankenpfleger*in", "Krankenpfleger*innen", "Krankenpfleger:", "Krankenpfleger*", "Kunde", "Kunden", "Kundin", "Kundinnen", "Kund:in", "Kund:innen", "Kund*in", "Kund*innen", "Kund:", "Kund*", "Kund", "Ladendieb", "Ladendiebs/Ladendiebes", "Ladendiebe", "Ladendieben", "Ladendiebin", "Ladendiebinnen", "Ladendieb:in", "Ladendieb:innen", "Ladendieb*in", "Ladendieb*innen", "Ladendieb:", "Ladendieb*", "Landwirt", "Landwirts/Landwirtes", "Landwirte", "Landwirten", "Landwirtin", "Landwirtinnen", "Landwirt:in", "Landwirt:innen", "Landwirt*in", "Landwirt*innen", "Landwirt:", "Landwirt*", "Lehrer", "Lehrers", "Lehrern", "Lehrerin", "Lehrerinnen", "Lehrer:in", "Lehrer:innen", "Lehrer*in", "Lehrer*innen", "Lehrer:", "Lehrer*", "Leser", "Lesers", "Lesern", "Leserin", "Leserinnen", "Leser:in", "Leser:innen", "Leser*in", "Leser*innen", "Leser:", "Leser*", "Logopäde", "Logopäden", "Logopädin", "Logopädinnen", "Logopäd:in", "Logopäd:innen", "Logopäd*in", "Logopäd*innen", "Logopäd:", "Logopäd*", "Logopäd", "Lokführer", "Lokführers", "Lokführern", "Lokführerin", "Lokführerinnen", "Lokführer:in", "Lokführer:innen", "Lokführer*in", "Lokführer*innen", "Lokführer:", "Lokführer*", "Mechatroniker", "Mechatronikers", "Mechatronikern", "Mechatronikerin", "Mechatronikerinnen", "Mechatroniker:in", "Mechatroniker:innen", "Mechatroniker*in", "Mechatroniker*innen", "Mechatroniker:", "Mechatroniker*", "Metzger", "Metzgers", "Metzgern", "Metzgerin", "Metzgerinnen", "Metzger:in", "Metzger:innen", "Metzger*in", "Metzger*innen", "Metzger:", "Metzger*", "Mieter", "Mieters", "Mietern", "Mieterin", "Mieterinnen", "Mieter:in", "Mieter:innen", "Mieter*in", "Mieter*innen", "Mieter:", "Mieter*", "Minijobber", "Minijobbers", "Minijobbern", "Minijobberin", "Minijobberinnen", "Minijobber:in", "Minijobber:innen", "Minijobber*in", "Minijobber*innen", "Minijobber:", "Minijobber*", "Mitarbeiter", "Mitarbeiters", "Mitarbeitern", "Mitarbeiterin", "Mitarbeiterinnen", "Mitarbeiter:in", "Mitarbeiter:innen", "Mitarbeiter*in", "Mitarbeiter*innen", "Mitarbeiter:", "Mitarbeiter*", "Moderator", "Moderators", "Moderatoren", "Moderatorin", "Moderatorinnen", "Moderator:in", "Moderator:innen", "Moderator*in", "Moderator*innen", "Moderator:", "Moderator*", "Nachbar", "Nachbarn", "Nachbarin", "Nachbarinnen", "Nachbar:in", "Nachbar:innen", "Nachbar*in", "Nachbar*innen", "Nachbar:", "Nachbar*", "Patient", "Patienten", "Patientin", "Patientinnen", "Patient:in", "Patient:innen", "Patient*in", "Patient*innen", "Patient:", "Patient*", "Pfarrer", "Pfarrers", "Pfarrern", "Pfarrerin", "Pfarrerinnen", "Pfarrer:in", "Pfarrer:innen", "Pfarrer*in", "Pfarrer*innen", "Pfarrer:", "Pfarrer*", "Physiotherapeut", "Physiotherapeuten", "Physiotherapeutin", "Physiotherapeutinnen", "Physiotherapeut:in", "Physiotherapeut:innen", "Physiotherapeut*in", "Physiotherapeut*innen", "Physiotherapeut:", "Physiotherapeut*", "Pilot", "Piloten", "Pilotin", "Pilotinnen", "Pilot:in", "Pilot:innen", "Pilot*in", "Pilot*innen", "Pilot:", "Pilot*", "Politiker", "Politikers", "Politikern", "Politikerin", "Politikerinnen", "Politiker:in", "Politiker:innen", "Politiker*in", "Politiker*innen", "Politiker:", "Politiker*", "Polizist", "Polizisten", "Polizistin", "Polizistinnen", "Polizist:in", "Polizist:innen", "Polizist*in", "Polizist*innen", "Polizist:", "Polizist*", "Postbote", "Postboten", "Postbotin", "Postbotinnen", "Postbot:in", "Postbot:innen", "Postbot*in", "Postbot*innen", "Postbot:", "Postbot*", "Postbot", "Professor", "Professors", "Professoren", "Professorin", "Professorinnen", "Professor:in", "Professor:innen", "Professor*in", "Professor*innen", "Professor:", "Professor*", "Programmierer", "Programmierers", "Programmierern", "Programmiererin", "Programmiererinnen", "Programmierer:in", "Programmierer:innen", "Programmierer*in", "Programmierer*innen", "Programmierer:", "Programmierer*", "Psychotherapeut", "Psychotherapeuten", "Psychotherapeutin", "Psychotherapeutinnen", "Psychotherapeut:in", "Psychotherapeut:innen", "Psychotherapeut*in", "Psychotherapeut*innen", "Psychotherapeut:", "Psychotherapeut*", "Radfahrer", "Radfahrers", "Radfahrern", "Radfahrerin", "Radfahrerinnen", "Radfahrer:in", "Radfahrer:innen", "Radfahrer*in", "Radfahrer*innen", "Radfahrer:", "Radfahrer*", "Regisseur", "Regisseurs", "Regisseure", "Regisseuren", "Regisseurin", "Regisseurinnen", "Regisseur:in", "Regisseur:innen", "Regisseur*in", "Regisseur*innen", "Regisseur:", "Regisseur*", "Rentner", "Rentners", "Rentnern", "Rentnerin", "Rentnerinnen", "Rentner:in", "Rentner:innen", "Rentner*in", "Rentner*innen", "Rentner:", "Rentner*", "Richter", "Richters", "Richtern", "Richterin", "Richterinnen", "Richter:in", "Richter:innen", "Richter*in", "Richter*innen", "Richter:", "Richter*", "Sanitäter", "Sanitäters", "Sanitätern", "Sanitäterin", "Sanitäterinnen", "Sanitäter:in", "Sanitäter:innen", "Sanitäter*in", "Sanitäter*innen", "Sanitäter:", "Sanitäter*", "Schaffner", "Schaffners", "Schaffnern", "Schaffnerin", "Schaffnerinnen", "Schaffner:in", "Schaffner:innen", "Schaffner*in", "Schaffner*innen", "Schaffner:", "Schaffner*", "Schauspieler", "Schauspielers", "Schauspielern", "Schauspielerin", "Schauspielerinnen", "Schauspieler:in", "Schauspieler:innen", "Schauspieler*in", "Schauspieler*innen", "Schauspieler:", "Schauspieler*", "Schriftsteller", "Schriftstellers", "Schriftstellern", "Schriftstellerin", "Schriftstellerinnen", "Schriftsteller:in", "Schriftsteller:innen", "Schriftsteller*in", "Schriftsteller*innen", "Schriftsteller:", "Schriftsteller*", "Schüler", "Schülers", "Schülern", "Schülerin", "Schülerinnen", "Schüler:in", "Schüler:innen", "Schüler*in", "Schüler*innen", "Schüler:", "Schüler*", "Schulleiter", "Schulleiters", "Schulleitern", "Schulleiterin", "Schulleiterinnen", "Schulleiter:in", "Schulleiter:innen", "Schulleiter*in", "Schulleiter*innen", "Schulleiter:", "Schulleiter*", "Soldat", "Soldaten", "Soldatin", "Soldatinnen", "Soldat:in", "Soldat:innen", "Soldat*in", "Soldat*innen", "Soldat:", "Soldat*", "Sozialarbeiter", "Sozialarbeiters", "Sozialarbeitern", "Sozialarbeiterin", "Sozialarbeiterinnen", "Sozialarbeiter:in", "Sozialarbeiter:innen", "Sozialarbeiter*in", "Sozialarbeiter*innen", "Sozialarbeiter:", "Sozialarbeiter*", "Steuerberater", "Steuerberaters", "Steuerberatern", "Steuerberaterin", "Steuerberaterinnen", "Steuerberater:in", "Steuerberater:innen", "Steuerberater*in", "Steuerberater*innen", "Steuerberater:", "Steuerberater*", "Straftäter", "Straftäters", "Straftätern", "Straftäterin", "Straftäterinnen", "Straftäter:in", "Straftäter:innen", "Straftäter*in", "Straftäter*innen", "Straftäter:", "Straftäter*", "Student", "Studenten", "Studentin", "Studentinnen", "Student:in", "Student:innen", "Student*in", "Student*innen", "Student:", "Student*", "Tierarzt", "Tierarztes", "Tierärzte", "Tierärzten", "Tierärztin", "Tierärztinnen", "Tierärzt:in", "Tierärzt:innen", "Tierärzt*in", "Tierärzt*innen", "Tierärzt:", "Tierärzt*", "Tierärzt", "Tierpfleger", "Tierpflegers", "Tierpflegern", "Tierpflegerin", "Tierpflegerinnen", "Tierpfleger:in", "Tierpfleger:innen", "Tierpfleger*in", "Tierpfleger*innen", "Tierpfleger:", "Tierpfleger*", "Tischler", "Tischlers", "Tischlern", "Tischlerin", "Tischlerinnen", "Tischler:in", "Tischler:innen", "Tischler*in", "Tischler*innen", "Tischler:", "Tischler*", "Tourist", "Touristen", "Touristin", "Touristinnen", "Tourist:in", "Tourist:innen", "Tourist*in", "Tourist*innen", "Tourist:", "Tourist*", "Übersetzer", "Übersetzers", "Übersetzern", "Übersetzerin", "Übersetzerinnen", "Übersetzer:in", "Übersetzer:innen", "Übersetzer*in", "Übersetzer*innen", "Übersetzer:", "Übersetzer*", "Verkäufer", "Verkäufers", "Verkäufern", "Verkäuferin", "Verkäuferinnen", "Verkäufer:in", "Verkäufer:innen", "Verkäufer*in", "Verkäufer*innen", "Verkäufer:", "Verkäufer*", "Wähler", "Wählers", "Wählern", "Wählerin", "Wählerinnen", "Wähler:in", "Wähler:innen", "Wähler*in", "Wähler*innen", "Wähler:", "Wähler*", "Zahntechniker", "Zahntechnikers", "Zahntechnikern", "Zahntechnikerin", "Zahntechnikerinnen", "Zahntechniker:in", "Zahntechniker:innen", "Zahntechniker*in", "Zahntechniker*innen", "Zahntechniker:", "Zahntechniker*", "Zeuge", "Zeugen", "Zeugin", "Zeuginnen", "Zeug:in", "Zeug:innen", "Zeug*in", "Zeug*innen", "Zeug:", "Zeug*", "Zeug", "Zugbegleiter", "Zugbegleiters", "Zugbegleitern", "Zugbegleiterin", "Zugbegleiterinnen", "Zugbegleiter:in", "Zugbegleiter:innen", "Zugbegleiter*in", "Zugbegleiter*innen", "Zugbegleiter:", "Zugbegleiter*", "Zuschauer", "Zuschauers", "Zuschauern", "Zuschauerin", "Zuschauerinnen", "Zuschauer:in", "Zuschauer:innen", "Zuschauer*in", "Zuschauer*innen", "Zuschauer:", "Zuschauer*"
      };

      elementHost1.Child = _editor;

      _user = new UserModel();
      _anno = new AnnotationModelOnline(_user);

      cmb_text.Items.Clear();
      var text_index = 0;

      foreach (var d in _anno.AvailableDocumentIds)
      {
        if (d == _user.Profile.LastDocumentId)
          text_index = cmb_text.Items.Count;

        var item = new RadListDataItem(d);
        if (_user.Profile.DoneDocumentIds.Contains(d))
        {
          item.Image = Resources.ok_button;
          item.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        cmb_text.Items.Add(item);
      }
      #endregion

      #region APP
      Text = $"QuickAnnotator (Hallo: {_user.Profile.UserName})";

      _init = false;
      cmb_text.SelectedIndex = text_index;
      #endregion

      #region STEPS
      foreach (var step in StepModel.Steps.Reverse())
      {
        step.Control.Dock = DockStyle.Top;
        step.StateSet(false);
        panel_controls.Controls.Add(step.Control);
      }
      #endregion
    }

    private int _editorIndexTmp = -1;
    private int _editorIndexFrom = -1;
    private int _editorIndexTo = -1;

    private void EditorOnRightClick(int index)
    {
      _editor.TemporaryAnnotation();
      _editorIndexTmp = index;
      _editor.TemporaryAnnotation(index);
    }

    private void EditorOnLeftClick(int index)
    {
      _editorIndexFrom = _editorIndexTmp;
      _editorIndexTmp = -1;

      _editor.TemporaryAnnotation();
      _editorIndexTo = index;

      DisplayExsistingAnnotation(index);
      _editor.TemporaryAnnotation(_editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom, _editorIndexTo);
    }

    private void DisplayExsistingAnnotation(int index)
    {
      // RESET
      foreach (var control in panel_controls.PanelContainer.Controls)
      {
        if (!(control is Panel panel))
          continue;

        foreach (Control option in panel.Controls)
          switch (option)
          {
            case RadCheckBox chk:
              chk.BackColor = Color.Transparent;
              break;
            case RadRadioButton radio:
              radio.BackColor = Color.Transparent;
              break;
          }
      }

      // SET
      var last = _anno.GetLastAnnotationState(index);
      StepModel.HighlightReset();
      if (last?.Annotation == null)
        return;

      StepModel.HighlightSet(last.Annotation);
    }

    private void btn_save_Click(object sender, EventArgs e)
    {
      if (QuickAnnotatorApi.SetDocumentCompletion(cmb_text.Items[cmb_text.SelectedIndex].Text))
      {
        _user.LoadProfile();
        foreach (var item in cmb_text.Items)
        {
          item.Image = _user.Profile.DoneDocumentIds.Contains(item.Text) ? Resources.ok_button : null;
          item.TextImageRelation = TextImageRelation.ImageBeforeText;
        }
      }
    }

    private void Cmb_textOnSelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
    {
      if (_init)
        return;

      btn_save_Click(null, null);

      _anno.SelectDocument = cmb_text.Items[cmb_text.SelectedIndex].Text;

      _editor.Tokens = _anno.EditorDocument;
      _editor.Annotations = _anno.EditorAnnotations;
    }

    private void btn_export_Click(object sender, EventArgs e)
    {
      var form = new ExportForm(cmb_text.Items[cmb_text.SelectedIndex].Text, _anno);
      form.ShowDialog();
    }

    private void btn_submit_Click(object sender, EventArgs e)
    {
      if (_editorIndexTo == -1)
        return;

      _anno.Annotate(new DocumentChange
      {
        From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
        To = _editorIndexTo + 1,
        Annotation = StepModel.GetAnnotation()
      });

      foreach (var control in panel_controls.PanelContainer.Controls)
      {
        if (!(control is Panel panel))
          continue;

        foreach (Control option in panel.Controls)
          switch (option)
          {
            case RadCheckBox chk:
              chk.IsChecked = false;
              break;
            case RadRadioButton radio:
              radio.IsChecked = false;
              break;
          }
      }

      StepModel.Reset();

      if (StepModel.IsDeleteState())
        _editor.Tokens = _anno.EditorDocument;
      _editor.Annotations = _anno.EditorAnnotations;
    }

    // NOTE -------------------------------------------- Start der Doppelformen ->
    // Wird nicht mehr verwendet
    //private void btn_submit_doppelform_Click(object sender, EventArgs e)
    //{
    //  var from = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom;
    //  var to = _editorIndexTo + 1;
    //  if (to - from < 2)
    //  {
    //    MessageBox.Show("Doppelformen müssen mehrere Token umfassen. Zuerst Rechtsklick auf erstes Token, dann Linksklick auf letztes Token.");
    //    return;
    //  }
    //
    //  _anno.Annotate(new DocumentChange
    //  {
    //    From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
    //    To = _editorIndexTo + 1,
    //    Annotation = new Dictionary<string, object>
    //    {
    //      {"Doppelform", "true"}
    //    }
    //  });
    //
    //  _editor.Annotations = _anno.EditorAnnotations;
    //}

    private void btn_submit_doppelform_altern_Click(object sender, EventArgs e)
    {
      var from = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom;
      var to = _editorIndexTo + 1;
      if (to - from < 2)
      {
        MessageBox.Show("Doppelformen müssen mehrere Token umfassen. Zuerst Rechtsklick auf erstes Token, dann Linksklick auf letztes Token.");
        return;
      }

      _anno.Annotate(new DocumentChange
      {
        From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
        To = _editorIndexTo + 1,
        Annotation = new Dictionary<string, object>
        {
          {"Doppelform", "true"}
        }
      });

      _editor.Annotations = _anno.EditorAnnotations;
    }

    private void btn_submit_doppelform_regu_Click(object sender, EventArgs e)
    {
      var from = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom;
      var to = _editorIndexTo + 1;
      if (to - from < 2)
      {
        MessageBox.Show("Doppelformen müssen mehrere Token umfassen. Zuerst Rechtsklick auf erstes Token, dann Linksklick auf letztes Token.");
        return;
      }

      _anno.Annotate(new DocumentChange
      {
        From = _editorIndexFrom == -1 ? _editorIndexTo : _editorIndexFrom,
        To = _editorIndexTo + 1,
        Annotation = new Dictionary<string, object>
        {
          {"Reguläre Doppelform", "true"}
        }
      });

      _editor.Annotations = _anno.EditorAnnotations;
    }
    // NOTE <-------------------------------------------- Ende der Doppelformen

    private void btn_screenFix_Click(object sender, EventArgs e)
    {
      foreach (Control c in panel_controls.PanelContainer.Controls)
      {
        if (!(c is StepControl step)) 
          continue;
        
        var nsize = step.Size.Height + 5;
        
        step.MaximumSize = step.MinimumSize = new Size(0, nsize);
        step.Size = new Size(step.Size.Width, nsize);
      }
    }
  }
}
