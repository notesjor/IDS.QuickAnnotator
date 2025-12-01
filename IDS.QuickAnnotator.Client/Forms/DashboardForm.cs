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
        "Altenpfleger:", "Altenpfleger*", "Altenpfleger", "Anwält:", "Anwält*", "Anwält", "Apotheker:", "Apotheker*", "Apotheker", "Arbeitnehmer:", "Arbeitnehmer*", "Arbeitnehmer", "Architekt:", "Architekt*", "Architekt", "Ärzt:", "Ärzt*", "Ärzt", "Arzthelfer:", "Arzthelfer*", "Arzthelfer", "Assistent:", "Assistent*", "Assistent", "Autofahrer:", "Autofahrer*", "Autofahrer", "Automechaniker:", "Automechaniker*", "Automechaniker", "Bäcker:", "Bäcker*", "Bäcker", "Barkeeper:", "Barkeeper*", "Barkeeper", "Bauingenieur:", "Bauingenieur*", "Bauingenieur", "Bestatter:", "Bestatter*", "Bestatter", "Besucher:", "Besucher*", "Besucher", "Bibliothekar:", "Bibliothekar*", "Bibliothekar", "Börsenmakler:", "Börsenmakler*", "Börsenmakler", "Bürger:", "Bürger*", "Bürger", "Bürgermeister:", "Bürgermeister*", "Bürgermeister", "Busfahrer:", "Busfahrer*", "Busfahrer", "Chef:", "Chef*", "Chef", "Chirurg:", "Chirurg*", "Chirurg", "Dachdecker:", "Dachdecker*", "Dachdecker", "Erzieher:", "Erzieher*", "Erzieher", "Fitnesstrainer:", "Fitnesstrainer*", "Fitnesstrainer", "Florist:", "Florist*", "Florist", "Flugbegleiter:", "Flugbegleiter*", "Flugbegleiter", "Fotograf:", "Fotograf*", "Fotograf", "Frauenärzt:", "Frauenärzt*", "Frauenärzt", "Freund:", "Freund*", "Freund", "Friseur:", "Friseur*", "Friseur", "Fußgänger:", "Fußgänger*", "Fußgänger", "Gamer:", "Gamer*", "Gamer", "Gastgeber:", "Gastgeber*", "Gastgeber", "Grafikdesigner:", "Grafikdesigner*", "Grafikdesigner", "Grundschullehrer:", "Grundschullehrer*", "Grundschullehrer", "Gymnasiallehrer:", "Gymnasiallehrer*", "Gymnasiallehrer", "Handwerker:", "Handwerker*", "Handwerker", "Hausmeister:", "Hausmeister*", "Hausmeister", "Hilfsarbeiter:", "Hilfsarbeiter*", "Hilfsarbeiter", "Ingenieur:", "Ingenieur*", "Ingenieur", "Jogger:", "Jogger*", "Jogger", "Journalist:", "Journalist*", "Journalist", "Jurist:", "Jurist*", "Jurist", "Kassierer:", "Kassierer*", "Kassierer", "Kellner:", "Kellner*", "Kellner", "Köch:", "Köch*", "Köch", "Kolleg:", "Kolleg*", "Kolleg", "Kosmetiker:", "Kosmetiker*", "Kosmetiker", "Krankenpfleger:", "Krankenpfleger*", "Krankenpfleger", "Kund:", "Kund*", "Kund", "Ladendieb:", "Ladendieb*", "Ladendieb", "Landwirt:", "Landwirt*", "Landwirt", "Lehrer:", "Lehrer*", "Lehrer", "Leser:", "Leser*", "Leser", "Logopäd:", "Logopäd*", "Logopäd", "Lokführer:", "Lokführer*", "Lokführer", "Mechatroniker:", "Mechatroniker*", "Mechatroniker", "Metzger:", "Metzger*", "Metzger", "Mieter:", "Mieter*", "Mieter", "Minijobber:", "Minijobber*", "Minijobber", "Mitarbeiter:", "Mitarbeiter*", "Mitarbeiter", "Moderator:", "Moderator*", "Moderator", "Nachbar:", "Nachbar*", "Nachbar", "Patient:", "Patient*", "Patient", "Pfarrer:", "Pfarrer*", "Pfarrer", "Physiotherapeut:", "Physiotherapeut*", "Physiotherapeut", "Pilot:", "Pilot*", "Pilot", "Politiker:", "Politiker*", "Politiker", "Polizist:", "Polizist*", "Polizist", "Postbot:", "Postbot*", "Postbot", "Professor:", "Professor*", "Professor", "Programmierer:", "Programmierer*", "Programmierer", "Psychotherapeut:", "Psychotherapeut*", "Psychotherapeut", "Radfahrer:", "Radfahrer*", "Radfahrer", "Regisseur:", "Regisseur*", "Regisseur", "Rentner:", "Rentner*", "Rentner", "Richter:", "Richter*", "Richter", "Sanitäter:", "Sanitäter*", "Sanitäter", "Schaffner:", "Schaffner*", "Schaffner", "Schauspieler:", "Schauspieler*", "Schauspieler", "Schriftsteller:", "Schriftsteller*", "Schriftsteller", "Schüler:", "Schüler*", "Schüler", "Schulleiter:", "Schulleiter*", "Schulleiter", "Soldat:", "Soldat*", "Soldat", "Sozialarbeiter:", "Sozialarbeiter*", "Sozialarbeiter", "Steuerberater:", "Steuerberater*", "Steuerberater", "Straftäter:", "Straftäter*", "Straftäter", "Student:", "Student*", "Student", "Tierärzt:", "Tierärzt*", "Tierärzt", "Tierpfleger:", "Tierpfleger*", "Tierpfleger", "Tischler:", "Tischler*", "Tischler", "Tourist:", "Tourist*", "Tourist", "Übersetzer:", "Übersetzer*", "Übersetzer", "Verkäufer:", "Verkäufer*", "Verkäufer", "Wähler:", "Wähler*", "Wähler", "Zahntechniker:", "Zahntechniker*", "Zahntechniker", "Zeug:", "Zeug*", "Zeug", "Zugbegleiter:", "Zugbegleiter*", "Zugbegleiter", "Zuschauer:", "Zuschauer*", "Zuschauer", "Altenpflegers", "Altenpflegern", "Altenpflegerin", "Altenpflegerinnen", "Altenpfleger:in", "Altenpfleger:innen", "Altenpfleger*in", "Altenpfleger*innen", "Anwalt", "Anwalts", "Anwälte", "Anwälten", "Anwältin", "Anwältinnen", "Anwält:in", "Anwält:innen", "Anwält*in", "Anwält*innen", "Apothekers", "Apothekern", "Apothekerin", "Apothekerinnen", "Apotheker:in", "Apotheker:innen", "Apotheker*in", "Apotheker*innen", "Arbeitnehmers", "Arbeitnehmern", "Arbeitnehmerin", "Arbeitnehmerinnen", "Arbeitnehmer:in", "Arbeitnehmer:innen", "Arbeitnehmer*in", "Arbeitnehmer*innen", "Architekts", "Architekten", "Architektin", "Architektinnen", "Architekt:in", "Architekt:innen", "Architekt*in", "Architekt*innen", "Arzt", "Arztes", "Ärzte", "Ärzten", "Ärztin", "Ärztinnen", "Ärzt:in", "Ärzt:innen", "Ärzt*in", "Ärzt*innen", "Arzthelfers", "Arzthelfern", "Arzthelferin", "Arzthelferinnen", "Arzthelfer:in", "Arzthelfer:innen", "Arzthelfer*in", "Arzthelfer*innen", "Assistenten", "Assistentin", "Assistentinnen", "Assistent:in", "Assistent:innen", "Assistent*in", "Assistent*innen", "Autofahrers", "Autofahrern", "Autofahrerin", "Autofahrerinnen", "Autofahrer:in", "Autofahrer:innen", "Autofahrer*in", "Autofahrer*innen", "Automechanikers", "Automechanikern", "Automechanikerin", "Automechanikerinnen", "Automechaniker:in", "Automechaniker:innen", "Automechaniker*in", "Automechaniker*innen", "Bäckers", "Bäckern", "Bäckerin", "Bäckerinnen", "Bäcker:in", "Bäcker:innen", "Bäcker*in", "Bäcker*innen", "Barkeepers", "Barkeepern", "Barkeeperin", "Barkeeperinnen", "Barkeeper:in", "Barkeeper:innen", "Barkeeper*in", "Barkeeper*innen", "Bauingenieurs", "Bauingenieure", "Bauingenieuren", "Bauingenieurin", "Bauingenieurinnen", "Bauingenieur:in", "Bauingenieur:innen", "Bauingenieur*in", "Bauingenieur*innen", "Bestatters", "Bestattern", "Bestatterin", "Bestatterinnen", "Bestatter:in", "Bestatter:innen", "Bestatter*in", "Bestatter*innen", "Besuchers", "Besuchern", "Besucherin", "Besucherinnen", "Besucher:in", "Besucher:innen", "Besucher*in", "Besucher*innen", "Bibliothekars", "Bibliothekare", "Bibliothekaren", "Bibliothekarin", "Bibliothekarinnen", "Bibliothekar:in", "Bibliothekar:innen", "Bibliothekar*in", "Bibliothekar*innen", "Börsenmaklers", "Börsenmaklern", "Börsenmaklerin", "Börsenmaklerinnen", "Börsenmakler:in", "Börsenmakler:innen", "Börsenmakler*in", "Börsenmakler*innen", "Bürgers", "Bürgern", "Bürgerin", "Bürgerinnen", "Bürger:in", "Bürger:innen", "Bürger*in", "Bürger*innen", "Bürgermeisters", "Bürgermeistern", "Bürgermeisterin", "Bürgermeisterinnen", "Bürgermeister:in", "Bürgermeister:innen", "Bürgermeister*in", "Bürgermeister*innen", "Busfahrers", "Busfahrern", "Busfahrerin", "Busfahrerinnen", "Busfahrer:in", "Busfahrer:innen", "Busfahrer*in", "Busfahrer*innen", "Chefs", "Chefin", "Chefinnen", "Chef:in", "Chef:innen", "Chef*in", "Chef*innen", "Chirurgs", "Chirurgen", "Chirurgin", "Chirurginnen", "Chirurg:in", "Chirurg:innen", "Chirurg*in", "Chirurg*innen", "Dachdeckers", "Dachdeckern", "Dachdeckerin", "Dachdeckerinnen", "Dachdecker:in", "Dachdecker:innen", "Dachdecker*in", "Dachdecker*innen", "Erziehers", "Erziehern", "Erzieherin", "Erzieherinnen", "Erzieher:in", "Erzieher:innen", "Erzieher*in", "Erzieher*innen", "Fitnesstrainers", "Fitnesstrainern", "Fitnesstrainerin", "Fitnesstrainerinnen", "Fitnesstrainer:in", "Fitnesstrainer:innen", "Fitnesstrainer*in", "Fitnesstrainer*innen", "Florists", "Floristen", "Floristin", "Floristinnen", "Florist:in", "Florist:innen", "Florist*in", "Florist*innen", "Flugbegleiters", "Flugbegleitern", "Flugbegleiterin", "Flugbegleiterinnen", "Flugbegleiter:in", "Flugbegleiter:innen", "Flugbegleiter*in", "Flugbegleiter*innen", "Fotografs", "Fotografen", "Fotografin", "Fotografinnen", "Fotograf:in", "Fotograf:innen", "Fotograf*in", "Fotograf*innen", "Frauenarzt", "Frauenarztes", "Frauenärzte", "Frauenärzten", "Frauenärztin", "Frauenärztinnen", "Frauenärzt:in", "Frauenärzt:innen", "Frauenärzt*in", "Frauenärzt*innen", "Freunds/Freundes", "Freunde", "Freunden", "Freundin", "Freundinnen", "Freund:in", "Freund:innen", "Freund*in", "Freund*innen", "Friseurs", "Friseure", "Friseuren", "Friseurin", "Friseurinnen", "Friseur:in", "Friseur:innen", "Friseur*in", "Friseur*innen", "Fußgängers", "Fußgängern", "Fußgängerin", "Fußgängerinnen", "Fußgänger:in", "Fußgänger:innen", "Fußgänger*in", "Fußgänger*innen", "Gamers", "Gamern", "Gamerin", "Gamerinnen", "Gamer:in", "Gamer:innen", "Gamer*in", "Gamer*innen", "Gastgebers", "Gastgebern", "Gastgeberin", "Gastgeberinnen", "Gastgeber:in", "Gastgeber:innen", "Gastgeber*in", "Gastgeber*innen", "Grafikdesigners", "Grafikdesignern", "Grafikdesignerin", "Grafikdesignerinnen", "Grafikdesigner:in", "Grafikdesigner:innen", "Grafikdesigner*in", "Grafikdesigner*innen", "Grundschullehrers", "Grundschullehrern", "Grundschullehrerin", "Grundschullehrerinnen", "Grundschullehrer:in", "Grundschullehrer:innen", "Grundschullehrer*in", "Grundschullehrer*innen", "Gymnasiallehrers", "Gymnasiallehrern", "Gymnasiallehrerin", "Gymnasiallehrerinnen", "Gymnasiallehrer:in", "Gymnasiallehrer:innen", "Gymnasiallehrer*in", "Gymnasiallehrer*innen", "Handwerkers", "Handwerkern", "Handwerkerin", "Handwerkerinnen", "Handwerker:in", "Handwerker:innen", "Handwerker*in", "Handwerker*innen", "Hausmeisters", "Hausmeistern", "Hausmeisterin", "Hausmeisterinnen", "Hausmeister:in", "Hausmeister:innen", "Hausmeister*in", "Hausmeister*innen", "Hilfsarbeiters", "Hilfsarbeitern", "Hilfsarbeiterin", "Hilfsarbeiterinnen", "Hilfsarbeiter:in", "Hilfsarbeiter:innen", "Hilfsarbeiter*in", "Hilfsarbeiter*innen", "Ingenieurs", "Ingenieure", "Ingenieuren", "Ingenieurin", "Ingenieurinnen", "Ingenieur:in", "Ingenieur:innen", "Ingenieur*in", "Ingenieur*innen", "Joggers", "Joggern", "Joggerin", "Joggerinnen", "Jogger:in", "Jogger:innen", "Jogger*in", "Jogger*innen", "Journalisten", "Journalistin", "Journalistinnen", "Journalist:in", "Journalist:innen", "Journalist*in", "Journalist*innen", "Juristen", "Juristin", "Juristinnen", "Jurist:in", "Jurist:innen", "Jurist*in", "Jurist*innen", "Kassierers", "Kassierern", "Kassiererin", "Kassiererinnen", "Kassierer:in", "Kassierer:innen", "Kassierer*in", "Kassierer*innen", "Kellners", "Kellnern", "Kellnerin", "Kellnerinnen", "Kellner:in", "Kellner:innen", "Kellner*in", "Kellner*innen", "Koch", "Kochs/Koches", "Köche", "Köchen", "Köchin", "Köchinnen", "Köch:in", "Köch:innen", "Köch*in", "Köch*innen", "Kollege", "Kollegen", "Kollegin", "Kolleginnen", "Kolleg:in", "Kolleg:innen", "Kolleg*in", "Kolleg*innen", "Kosmetikers", "Kosmetikern", "Kosmetikerin", "Kosmetikerinnen", "Kosmetiker:in", "Kosmetiker:innen", "Kosmetiker*in", "Kosmetiker*innen", "Krankenpflegers", "Krankenpflegern", "Krankenpflegerin", "Krankenpflegerinnen", "Krankenpfleger:in", "Krankenpfleger:innen", "Krankenpfleger*in", "Krankenpfleger*innen", "Kunde", "Kunden", "Kundin", "Kundinnen", "Kund:in", "Kund:innen", "Kund*in", "Kund*innen", "Ladendiebs/Ladendiebes", "Ladendiebe", "Ladendieben", "Ladendiebin", "Ladendiebinnen", "Ladendieb:in", "Ladendieb:innen", "Ladendieb*in", "Ladendieb*innen", "Landwirts/Landwirtes", "Landwirte", "Landwirten", "Landwirtin", "Landwirtinnen", "Landwirt:in", "Landwirt:innen", "Landwirt*in", "Landwirt*innen", "Lehrers", "Lehrern", "Lehrerin", "Lehrerinnen", "Lehrer:in", "Lehrer:innen", "Lehrer*in", "Lehrer*innen", "Lesers", "Lesern", "Leserin", "Leserinnen", "Leser:in", "Leser:innen", "Leser*in", "Leser*innen", "Logopäde", "Logopäden", "Logopädin", "Logopädinnen", "Logopäd:in", "Logopäd:innen", "Logopäd*in", "Logopäd*innen", "Lokführers", "Lokführern", "Lokführerin", "Lokführerinnen", "Lokführer:in", "Lokführer:innen", "Lokführer*in", "Lokführer*innen", "Mechatronikers", "Mechatronikern", "Mechatronikerin", "Mechatronikerinnen", "Mechatroniker:in", "Mechatroniker:innen", "Mechatroniker*in", "Mechatroniker*innen", "Metzgers", "Metzgern", "Metzgerin", "Metzgerinnen", "Metzger:in", "Metzger:innen", "Metzger*in", "Metzger*innen", "Mieters", "Mietern", "Mieterin", "Mieterinnen", "Mieter:in", "Mieter:innen", "Mieter*in", "Mieter*innen", "Minijobbers", "Minijobbern", "Minijobberin", "Minijobberinnen", "Minijobber:in", "Minijobber:innen", "Minijobber*in", "Minijobber*innen", "Mitarbeiters", "Mitarbeitern", "Mitarbeiterin", "Mitarbeiterinnen", "Mitarbeiter:in", "Mitarbeiter:innen", "Mitarbeiter*in", "Mitarbeiter*innen", "Moderators", "Moderatoren", "Moderatorin", "Moderatorinnen", "Moderator:in", "Moderator:innen", "Moderator*in", "Moderator*innen", "Nachbarn", "Nachbarin", "Nachbarinnen", "Nachbar:in", "Nachbar:innen", "Nachbar*in", "Nachbar*innen", "Patienten", "Patientin", "Patientinnen", "Patient:in", "Patient:innen", "Patient*in", "Patient*innen", "Pfarrers", "Pfarrern", "Pfarrerin", "Pfarrerinnen", "Pfarrer:in", "Pfarrer:innen", "Pfarrer*in", "Pfarrer*innen", "Physiotherapeuten", "Physiotherapeutin", "Physiotherapeutinnen", "Physiotherapeut:in", "Physiotherapeut:innen", "Physiotherapeut*in", "Physiotherapeut*innen", "Piloten", "Pilotin", "Pilotinnen", "Pilot:in", "Pilot:innen", "Pilot*in", "Pilot*innen", "Politikers", "Politikern", "Politikerin", "Politikerinnen", "Politiker:in", "Politiker:innen", "Politiker*in", "Politiker*innen", "Polizisten", "Polizistin", "Polizistinnen", "Polizist:in", "Polizist:innen", "Polizist*in", "Polizist*innen", "Postbote", "Postboten", "Postbotin", "Postbotinnen", "Postbot:in", "Postbot:innen", "Postbot*in", "Postbot*innen", "Professors", "Professoren", "Professorin", "Professorinnen", "Professor:in", "Professor:innen", "Professor*in", "Professor*innen", "Programmierers", "Programmierern", "Programmiererin", "Programmiererinnen", "Programmierer:in", "Programmierer:innen", "Programmierer*in", "Programmierer*innen", "Psychotherapeuten", "Psychotherapeutin", "Psychotherapeutinnen", "Psychotherapeut:in", "Psychotherapeut:innen", "Psychotherapeut*in", "Psychotherapeut*innen", "Radfahrers", "Radfahrern", "Radfahrerin", "Radfahrerinnen", "Radfahrer:in", "Radfahrer:innen", "Radfahrer*in", "Radfahrer*innen", "Regisseurs", "Regisseure", "Regisseuren", "Regisseurin", "Regisseurinnen", "Regisseur:in", "Regisseur:innen", "Regisseur*in", "Regisseur*innen", "Rentners", "Rentnern", "Rentnerin", "Rentnerinnen", "Rentner:in", "Rentner:innen", "Rentner*in", "Rentner*innen", "Richters", "Richtern", "Richterin", "Richterinnen", "Richter:in", "Richter:innen", "Richter*in", "Richter*innen", "Sanitäters", "Sanitätern", "Sanitäterin", "Sanitäterinnen", "Sanitäter:in", "Sanitäter:innen", "Sanitäter*in", "Sanitäter*innen", "Schaffners", "Schaffnern", "Schaffnerin", "Schaffnerinnen", "Schaffner:in", "Schaffner:innen", "Schaffner*in", "Schaffner*innen", "Schauspielers", "Schauspielern", "Schauspielerin", "Schauspielerinnen", "Schauspieler:in", "Schauspieler:innen", "Schauspieler*in", "Schauspieler*innen", "Schriftstellers", "Schriftstellern", "Schriftstellerin", "Schriftstellerinnen", "Schriftsteller:in", "Schriftsteller:innen", "Schriftsteller*in", "Schriftsteller*innen", "Schülers", "Schülern", "Schülerin", "Schülerinnen", "Schüler:in", "Schüler:innen", "Schüler*in", "Schüler*innen", "Schulleiters", "Schulleitern", "Schulleiterin", "Schulleiterinnen", "Schulleiter:in", "Schulleiter:innen", "Schulleiter*in", "Schulleiter*innen", "Soldaten", "Soldatin", "Soldatinnen", "Soldat:in", "Soldat:innen", "Soldat*in", "Soldat*innen", "Sozialarbeiters", "Sozialarbeitern", "Sozialarbeiterin", "Sozialarbeiterinnen", "Sozialarbeiter:in", "Sozialarbeiter:innen", "Sozialarbeiter*in", "Sozialarbeiter*innen", "Steuerberaters", "Steuerberatern", "Steuerberaterin", "Steuerberaterinnen", "Steuerberater:in", "Steuerberater:innen", "Steuerberater*in", "Steuerberater*innen", "Straftäters", "Straftätern", "Straftäterin", "Straftäterinnen", "Straftäter:in", "Straftäter:innen", "Straftäter*in", "Straftäter*innen", "Studenten", "Studentin", "Studentinnen", "Student:in", "Student:innen", "Student*in", "Student*innen", "Tierarzt", "Tierarztes", "Tierärzte", "Tierärzten", "Tierärztin", "Tierärztinnen", "Tierärzt:in", "Tierärzt:innen", "Tierärzt*in", "Tierärzt*innen", "Tierpflegers", "Tierpflegern", "Tierpflegerin", "Tierpflegerinnen", "Tierpfleger:in", "Tierpfleger:innen", "Tierpfleger*in", "Tierpfleger*innen", "Tischlers", "Tischlern", "Tischlerin", "Tischlerinnen", "Tischler:in", "Tischler:innen", "Tischler*in", "Tischler*innen", "Touristen", "Touristin", "Touristinnen", "Tourist:in", "Tourist:innen", "Tourist*in", "Tourist*innen", "Übersetzers", "Übersetzern", "Übersetzerin", "Übersetzerinnen", "Übersetzer:in", "Übersetzer:innen", "Übersetzer*in", "Übersetzer*innen", "Verkäufers", "Verkäufern", "Verkäuferin", "Verkäuferinnen", "Verkäufer:in", "Verkäufer:innen", "Verkäufer*in", "Verkäufer*innen", "Wählers", "Wählern", "Wählerin", "Wählerinnen", "Wähler:in", "Wähler:innen", "Wähler*in", "Wähler*innen", "Zahntechnikers", "Zahntechnikern", "Zahntechnikerin", "Zahntechnikerinnen", "Zahntechniker:in", "Zahntechniker:innen", "Zahntechniker*in", "Zahntechniker*innen", "Zeuge", "Zeugen", "Zeugin", "Zeuginnen", "Zeug:in", "Zeug:innen", "Zeug*in", "Zeug*innen", "Zugbegleiters", "Zugbegleitern", "Zugbegleiterin", "Zugbegleiterinnen", "Zugbegleiter:in", "Zugbegleiter:innen", "Zugbegleiter*in", "Zugbegleiter*innen", "Zuschauers", "Zuschauern", "Zuschauerin", "Zuschauerinnen", "Zuschauer:in", "Zuschauer:innen", "Zuschauer*in", "Zuschauer*innen"
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
